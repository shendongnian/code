    [AttributeUsage (AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	sealed class RestrictedInheritabilityAttribute : Attribute
	{
		public List<Type> AllowedTypes = new List<Type> ();
		public RestrictedInheritabilityAttribute (Type allowed)
		{
			AllowedTypes.Add (allowed);
		}
		public RestrictedInheritabilityAttribute (params Type[] allowed)
		{
			AllowedTypes.AddRange (allowed);
		}
		public bool CheckForException (Type primary)
		{
			foreach (Type t in AllowedTypes)
			{
				if (primary == t) return true;
			}
			throw new RestrictedInheritanceException (primary);
		}
	}
