	using System;
	using System.Collections.Generic;
	using System.Linq;
	public class Program
	{
	   public static void Main()
	   {
		  var userManager = new UserManager();
		  // self referencing manager?
		  var user1 = new User { Id = 1, ManagerId = 1 };
		  // two users managing each other
		  var user2 = new User { Id = 2, ManagerId = 3 };
		  var user3 = new User { Id = 3, ManagerId = 2 };
		  // three users managing each other
		  var user4 = new User { Id = 4, ManagerId = 5 };
		  var user5 = new User { Id = 5, ManagerId = 6 };
		  var user6 = new User { Id = 6, ManagerId = 4 };
		  // no manager?
		  var user7 = new User { Id = 7, };
		  IUser outUser;
		  Console.WriteLine($"added user?{userManager.TryAdd(user1, out outUser)} user added:{outUser.ToConsole()}");
		  Console.WriteLine($"added user?{userManager.TryAdd(user2, out outUser)} user added:{outUser.ToConsole()}");
		  Console.WriteLine($"added user?{userManager.TryAdd(user3, out outUser)} user added:{outUser.ToConsole()}");
		  Console.WriteLine($"added user?{userManager.TryAdd(user4, out outUser)} user added:{outUser.ToConsole()}");
		  Console.WriteLine($"added user?{userManager.TryAdd(user5, out outUser)} user added:{outUser.ToConsole()}");
		  Console.WriteLine($"added user?{userManager.TryAdd(user6, out outUser)} user added:{outUser.ToConsole()}");
		  Console.WriteLine($"added user?{userManager.TryAdd(user7, out outUser)} user added:{outUser.ToConsole()}");
		  Console.WriteLine("done adding...");
		  Console.WriteLine("Current users:");
		  foreach(var kvp in userManager.Users)
		  {
			 Console.WriteLine($"{kvp.Value.ToConsole()}");
		  }
	   }
	   public class UserManager
	   {
		  private Dictionary<int, User> _users = new Dictionary<int, User>();
		  public IReadOnlyDictionary<int, IUser> Users
		  {
			 get
			 {
				return _users
				.Select(kvp => new { Key = kvp.Key, Value = kvp.Value as IUser })
				.ToDictionary(a => a.Key, a => a.Value);
			 }
		  }
		  public bool TryAdd(IUser user, out IUser userResult)
		  {
			 userResult = null;
			 var result = !IsUserCircular(user);
			 if (result)
			 {
				var validUser = new User { Id = user.Id, ManagerId = user.ManagerId };
				_users.Add(validUser.Id, validUser);
				userResult = validUser;
			 }
			 return result;
		  }
		  private bool IsUserCircular(IUser user)
		  {
			 var currentUser = user;
			 var currentManagers = new HashSet<int> { user.Id };
			 var result = false;
			 while (currentUser?.ManagerId != null)
			 {
				// just because they have an Id doesn't mean that user exists...
				// or does it?
				if (currentManagers.Contains(currentUser.ManagerId.Value))
				{
				   // we've come full circle to the same user through X users
				   result = currentManagers.Count > 2;
				   break;
				}
				else
				{
				   if (_users.TryGetValue(currentUser.ManagerId.Value, out User nextUser))
				   {
					  currentManagers.Add(currentUser.ManagerId.Value);
					  currentUser = nextUser;
				   }
				   else
				   {
					  // user has Manager that doesn't exist in our system
					  currentUser = null;
				   }
				}
			 }
			 return result;
		  }
	   }
	}
	public interface IUser
	{
	   int Id { get; }
	   int? ManagerId { get; }
	}
	public class User : IUser
	{
	   public int Id { get; set; }
	   public int? ManagerId { get; set; }
	}
	public static class IUserExtensions
	{
	   public static string ToConsole(this IUser user)
	   {
		  if (user == null)
			 return $"null";
		  return $"Id={user.Id} ManagerId={(user.ManagerId.HasValue ? user.ManagerId.ToString() : "null")}";
	   }
	}
