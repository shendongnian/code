    public class UserRepository : GenericRepository<User>
	{
		IEnumerable<User> GetUserByCustomCriteria()
		{
		}
		User GetUserDetailsWithPhones()
		{
			// Populate User along with Phones
		}
		User GetUserDetailsWithAllSubInfo()
		{
			// Populate User along with all sub information e.g. phones, addresses etc.
		}
	}
	
