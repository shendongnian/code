    public class Service{
	private List<User> _users;
	public List<User> Users {
		get{
			from u in _users where u.DateEnd == null select u
		}
	}
	...
