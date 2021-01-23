        //This structure represents the comparison of one member of an object to the corresponding member of another object.
		public struct MemberComparison
		{
			public readonly MemberInfo Member; //Which member this Comparison compares
			public readonly object Value1, Value2;//The values of each object's respective member
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
        //This method can be used to get a list of MemberComparison values that represent the fields and/or properties that differ between the two objects.
		public List<MemberComparison> ReflectiveCompare<T>(T x, T y)
		{
			List<MemberComparison> list = new List<MemberComparison>();//The list to be returned
			foreach (MemberInfo m in typeof(T).GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))
				//Only look at fields and properties.
				//This could be changed to include methods, but you'd have to get values to pass to the methods you want to compare
				if (m.MemberType == MemberTypes.Field)
				{
					FieldInfo field = (FieldInfo)m;
					var xValue = field.GetValue(x);
					var yValue = field.GetValue(y);
					if (!yValue.Equals(xValue))//Add a new comparison to the list if the value of the member defined on 'x' isn't equal to the value of the member defined on 'y'.
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
