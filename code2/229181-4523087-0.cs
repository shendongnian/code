		public struct MemberComparison
		{
			public readonly MemberInfo Member;
			public readonly object Value1, Value2;
			public MemberComparison(MemberInfo member, object value1, object value2)
			{
				Member = member;
				Value1 = value1;
				Value2 = value2;
			}
			public override string ToString()
			{
				return Member.Name + ": " + Value1.ToString() + (Value1.Equals(Value2) ? " == " : " != ") + Value2.ToString();
			}
		}
		public List<MemberComparison> ReflectiveCompare<T>(T x, T y)
		{
			List<MemberComparison> list = new List<MemberComparison>();
			foreach (MemberInfo m in typeof(T).GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))
				if (m.MemberType == MemberTypes.Field)
				{
					FieldInfo field = (FieldInfo)m;
					var xValue = field.GetValue(x);
					var yValue = field.GetValue(y);
					if (!yValue.Equals(xValue))
						list.Add(new MemberComparison(field, yValue, xValue));
				}
				else if (m.MemberType == MemberTypes.Property)
				{
					var prop = (PropertyInfo)m;
					if (prop.CanRead && prop.GetGetMethod().GetParameters().Length == 0)
					{
						var xValue = prop.GetValue(x, null);
						var yValue = prop.GetValue(y, null);
						if (!xValue.Equals(yValue))
							list.Add(new MemberComparison(prop, xValue, yValue));
					}
					else//Ignore properties that aren't readable or are indexers
						continue;
				}
			return list;
		}
