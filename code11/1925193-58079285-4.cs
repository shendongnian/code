		public static Tout CloneAndCast<Tin, Tout>(Tin source)
			where Tin : class
			where Tout : class, new()
		{
			if(source != null)
			{
				var clone = new Tout();
				IEnumerable<PropertyInfo> membersIn = typeof(Tin).GetProperties();
				PropertyInfo[] membersOut = typeof(Tout).GetProperties();
				foreach(PropertyInfo member in membersIn)
				{
					membersOut.FirstOrDefault(o => o.Name == member.Name)?.SetValue(clone, member.GetValue(source));
				}
				return clone;
			}
			else
			{
				return null;
			}
		}
