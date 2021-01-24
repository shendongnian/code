lang-csharp
public abstract class UsersMenu
{
}
public abstract class Home
{
}
public abstract class DropdownMenu2
{
}
public class HeaderNavigationMenu
{
	public HeaderNavigationMenu()
	{
		UsersMenu = new UsersMenuImpl();
		Home = new HomeImpl();
		DropdownMenu2 = new DropdownMenu2Impl();
	}
	public UsersMenu UsersMenu { get; }
	public Home Home { get; }
	public DropdownMenu2 DropdownMenu2 { get; }
	
	private class UsersMenuImpl : UsersMenu
	{
	}
	
	private class HomeImpl : Home
	{
	}
	
	private class DropdownMenu2Impl : DropdownMenu2
	{
	}
}
Fellow developers can see and use the `UsersMenu`, `Home`, and `DropdownMenu2` `abstract` classes, but cannot create instances of them. Only `HeaderNavigationMenu` can.
Of course, another developer could always create their own classes deriving from the `public abstract` ones, but there is only so much you can do. `UsersMenu`, `Home`, and `DropdownMenu2` have to be `public` in order to be `public` properties.
