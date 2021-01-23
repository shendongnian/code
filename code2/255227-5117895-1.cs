	public static class RolesExtensions
	{
		public static bool HasAnyOf(this Roles r1, Roles roles)
		{
			return (r1 & roles) > 0;
		}
	}
