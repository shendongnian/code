    public static class GetterGenerator<T>
		{
			private readonly static Type type = typeof(T);
			private readonly static Dictionary<string, Func<T, object>> getters = Generate();
			private readonly static PropertyInfo[] properties = type.GetProperties().ToArray();
			private static Dictionary<string, Func<T, object>> Generate()
			{
				PropertyInfo[] properties = type.GetProperties().ToArray();
				int propertiesLength = properties.Length;
				var props = new Dictionary<string, Func<T, object>>(propertiesLength);
				for (int i = 0; i < propertiesLength; i++)
				{
					ParameterExpression p = LambdaExpression.Parameter(typeof(T), "p");
					LambdaExpression l = LambdaExpression.Lambda<Func<T, object>>(
						LambdaExpression.Convert(
							LambdaExpression.Property(p, properties[i]), typeof(object)
						), p);
					props.Add(properties[i].Name, l.Compile() as Func<T, object>);
				}
				return props;
			}
			public static Dictionary<string, Func<T, object>> GettersDictionary
			{
				get { return getters; }
			}
			public static Func<T, object>[] Getters
			{
				get { return getters.Values.ToArray(); }
			}
			public static PropertyInfo[] Properties 
			{
				get { return properties;}
			}
		}
		public class EntityReader<T> : IDataReader
		{
			private Func<T, object>[] getters = GetterGenerator<T>.Getters;
			private Dictionary<string, Func<T, object>> gettersDictionary = GetterGenerator<T>.GettersDictionary;
			private PropertyInfo[] properties = GetterGenerator<T>.Properties;
			private IEnumerator<T> enumerator;
			private int affected = 0;
			
			public EntityReader(IEnumerable<T> enumerable)
			{
				enumerator = enumerable.GetEnumerator();
			}
			#region IDataReader Members
			public void Close()
			{
			}
			public int Depth
			{
				get { return 0; }
			}
			public DataTable GetSchemaTable()
			{
				throw new NotImplementedException();
			}
			public bool IsClosed
			{
				get { return false; }
			}
			public bool NextResult()
			{
				return false;
			}
			public bool Read()
			{
				bool read = enumerator.MoveNext();
				if (read)
					affected++;
				return read;
			}
			public int RecordsAffected
			{
				get { return affected; }
			}
			#endregion
			#region IDisposable Members
			public void Dispose()
			{
				properties = null;
				getters = null;
				gettersDictionary = null;
				enumerator = null;
				affected = 0;
			}
			#endregion
			#region IDataRecord Members
			public int FieldCount
			{
				get { return getters.Length; }
			}
			private Y GetValue<Y>(int i)
			{
				try
				{
					return (Y)GetValue(i);
				}
				catch (InvalidCastException)
				{
					throw new InvalidCastException(string.Format("Invalid cast from '{0}' to '{1}'", GetFieldType(i), typeof(Y)));
				}
			}
			public bool GetBoolean(int i)
			{
				return GetValue<bool>(i);
			}
			public byte GetByte(int i)
			{
				return GetValue<byte>(i);
			}
			public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
			{
				throw new NotImplementedException();
			}
			public char GetChar(int i)
			{
				return GetValue<char>(i);
			}
			public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
			{
				throw new NotImplementedException();
			}
			public IDataReader GetData(int i)
			{
				throw new NotImplementedException();
			}
			public string GetDataTypeName(int i)
			{
				return GetFieldType(i).Name;
			}
			public DateTime GetDateTime(int i)
			{
				return GetValue<DateTime>(i);
			}
			public decimal GetDecimal(int i)
			{
				return GetValue<decimal>(i);
			}
			public double GetDouble(int i)
			{
				return GetValue<double>(i);
			}
			public Type GetFieldType(int i)
			{
				return properties[i].PropertyType;
			}
			public float GetFloat(int i)
			{
				return GetValue<float>(i);
			}
			public Guid GetGuid(int i)
			{
				return GetValue<Guid>(i);
			}
			public short GetInt16(int i)
			{
				return GetValue<short>(i);
			}
			public int GetInt32(int i)
			{
				return GetValue<int>(i);
			}
			public long GetInt64(int i)
			{
				return GetValue<long>(i);
			}
			public string GetName(int i)
			{
				return properties[i].Name;
			}
			public int GetOrdinal(string name)
			{
				bool found = false;
				int i = 0;
				int propertiesLength = properties.Length;
				while (!found && i < propertiesLength)
					found = properties[i++].Name == name;
				if (!found)
					i = -1;
				return i;
			}
			public string GetString(int i)
			{
				return GetValue<string>(i);
			}
			public object GetValue(int i)
			{
				return getters[i](enumerator.Current);
			}
			public int GetValues(object[] values)
			{
				int length = Math.Min(values.Length, getters.Length);
				for (int i = 0; i < length; i++)
					values[i] = getters[i](enumerator.Current);
				return length;
			}
			public bool IsDBNull(int i)
			{
				return GetValue(i) == null;
			}
			public object this[string name]
			{
				get { return GetValue(GetOrdinal(name)); }
			}
			public object this[int i]
			{
				get { return GetValue(i); }
			}
			#endregion
		}
		public static void Insert<T>(this OracleBulkCopy copy, IEnumerable<T> entities, Dictionary<string, string> ColumnMap) 
			where T : class
		{
			copy.ColumnMappings.Clear();
			foreach (var map in ColumnMap)
				copy.ColumnMappings.Add(map.Key, map.Value);
			IDataReader reader = new EntityReader<T>(entities);
			copy.WriteToServer(reader);
		}
