    public class TableTypeDynamicParam<T> : Dapper.SqlMapper.IDynamicParameters
    {
        IEnumerable<T> MyList;
        Dictionary<string, int> ordinals;
        Dictionary<Type, SqlDbType> typeMap;
        string ParameterName, TableTypeName;
        public TableTypeDynamicParam(IEnumerable<T> listValue, string parameterName, string tableTypeName)
        {
            this.MyList = listValue;
            this.ParameterName = parameterName;
            this.TableTypeName = tableTypeName;
            ordinals = new Dictionary<string, int>();
            SetTypeMap();
        }
        void SetTypeMap()
        {
            typeMap = new Dictionary<Type, SqlDbType>();
            typeMap[typeof(byte)] = SqlDbType.TinyInt;
            typeMap[typeof(sbyte)] = SqlDbType.TinyInt;
            typeMap[typeof(short)] = SqlDbType.SmallInt;
            typeMap[typeof(ushort)] = SqlDbType.SmallInt;
            typeMap[typeof(int)] = SqlDbType.Int;
            typeMap[typeof(uint)] = SqlDbType.Int;
            typeMap[typeof(long)] = SqlDbType.Int;
            typeMap[typeof(ulong)] = SqlDbType.BigInt;
            typeMap[typeof(float)] = SqlDbType.Float;
            typeMap[typeof(double)] = SqlDbType.Float;
            typeMap[typeof(decimal)] = SqlDbType.Decimal;
            typeMap[typeof(bool)] = SqlDbType.Bit;
            typeMap[typeof(string)] = SqlDbType.Text;
            typeMap[typeof(char)] = SqlDbType.Char;
            typeMap[typeof(Guid)] = SqlDbType.UniqueIdentifier;
            typeMap[typeof(DateTime)] = SqlDbType.DateTime;
            typeMap[typeof(DateTimeOffset)] = SqlDbType.DateTimeOffset;
            typeMap[typeof(byte[])] = SqlDbType.Binary;
            typeMap[typeof(byte?)] = SqlDbType.TinyInt;
            typeMap[typeof(sbyte?)] = SqlDbType.TinyInt;
            typeMap[typeof(short?)] = SqlDbType.SmallInt;
            typeMap[typeof(ushort?)] = SqlDbType.SmallInt;
            typeMap[typeof(int?)] = SqlDbType.Int;
            typeMap[typeof(uint?)] = SqlDbType.Int;
            typeMap[typeof(long?)] = SqlDbType.BigInt;
            typeMap[typeof(ulong?)] = SqlDbType.BigInt;
            typeMap[typeof(float?)] = SqlDbType.Float;
            typeMap[typeof(double?)] = SqlDbType.Float;
            typeMap[typeof(decimal?)] = SqlDbType.Decimal;
            typeMap[typeof(bool?)] = SqlDbType.Bit;
            typeMap[typeof(char?)] = SqlDbType.Char;
            typeMap[typeof(Guid?)] = SqlDbType.UniqueIdentifier;
            typeMap[typeof(DateTime?)] = SqlDbType.DateTime;
            typeMap[typeof(DateTimeOffset?)] = SqlDbType.DateTimeOffset;
            //  typeMap[typeof(System.Data.Linq.Binary)] = SqlDbType.Binary;
        }
        SqlDbType GetSqlDBType(Type t)
        {
            # region other tries
            /*  SqlParameter p1 = new SqlParameter();
            
                 TypeConverter tc = TypeDescriptor.GetConverter(p1.DbType);
                 if (tc.CanConvertFrom(theType))
                     p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
                 else
                 {
                     //Try brute force
                     try
                     {
                         p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
                     }
                     catch {} //Do Nothing
                 }
                 return p1.SqlDbType; 
                 Microsoft.SqlServer.Server.SqlMetaData sm = Microsoft.SqlServer.Server.SqlMetaData.InferFromValue(new byte[] { 1, 2 }, "someName");
    sm = Microsoft.SqlServer.Server.SqlMetaData.InferFromValue(2.3, "someName");
    sm = Microsoft.SqlServer.Server.SqlMetaData.InferFromValue(11, "someName");
    sm =     Microsoft.SqlServer.Server.SqlMetaData.InferFromValue(System.Web.HttpValidationStatus.Valid, "someName");
    sm = Microsoft.SqlServer.Server.SqlMetaData.InferFromValue("hello", "someName");
 
    Console.WriteLine(sm.SqlDbType);
    Console.WriteLine(sm.TypeName);
    Console.WriteLine(sm.MaxLength);
                 
                 */
            # endregion
            return typeMap[t];
        }
        void SetRecordValue(ref Microsoft.SqlServer.Server.SqlDataRecord rec, string propertyName, object value, Type propertyType)
        {
            switch (propertyType.ToString())
            {
                //need to cover all type case
                case "System.Int32":
                    rec.SetInt32(ordinals[propertyName], (int)value);
                    break;
                case "System.Int64":
                    rec.SetInt64(ordinals[propertyName], (long)value);
                    break;
                case "System.Boolean":
                    rec.SetBoolean(ordinals[propertyName], (bool)value);
                    break;
                case "System.String":
                default:
                    rec.SetString(ordinals[propertyName], Convert.ToString(value));
                    break;
            }
        }
        public void AddParameters(IDbCommand command)
        {
            var sqlCommand = (SqlCommand)command;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Microsoft.SqlServer.Server.SqlDataRecord> tableType_list = new List<Microsoft.SqlServer.Server.SqlDataRecord>();
            var first = MyList.FirstOrDefault();
            if (null != first)
            {
                var lstDefinition = new List<Microsoft.SqlServer.Server.SqlMetaData>();
                int i = 0;
                foreach (var prop in first.GetType().GetProperties())
                {
                    lstDefinition.Add(new Microsoft.SqlServer.Server.SqlMetaData(prop.Name, GetSqlDBType(prop.PropertyType)));
                    ordinals.Add(prop.Name, i++);
                }
                // Create an SqlMetaData object that describes our table type.
                // Microsoft.SqlServer.Server.SqlMetaData[] tvp_definition = { new Microsoft.SqlServer.Server.SqlMetaData("n", SqlDbType.Int) };
                foreach (var l in MyList)
                {
                    // Create a new record, using the metadata array above.
                    Microsoft.SqlServer.Server.SqlDataRecord rec = new Microsoft.SqlServer.Server.SqlDataRecord(lstDefinition.ToArray());
                    foreach (var prop in first.GetType().GetProperties())
                    {
                        // rec.SetInt32(ordinals[prop.Name], prop.GetValue(l));    // Set the value.
                        SetRecordValue(ref rec, prop.Name, prop.GetValue(l), prop.GetType());
                    }
                    tableType_list.Add(rec);      // Add it to the list.
                }
            }
            // Add the table parameter.
            var p = sqlCommand.Parameters.Add("@" + ParameterName.TrimStart('@'), SqlDbType.Structured);
            p.Direction = ParameterDirection.Input;
            p.TypeName = TableTypeName;
            if (null != first)
                p.Value = tableType_list;
            else
                p.Value = DBNull.Value;
        }
        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            AddParameters(command);
        }
    }
