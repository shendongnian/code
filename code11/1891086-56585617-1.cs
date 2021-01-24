c#
class Program
{
    static void Main(string[] args)
    {
        HeaderNavigationMenu navigationMenu = new HeaderNavigationMenu();
        navigationMenu.DropdownMenu2.SelectOption3();
        // This line will no longer work because the constructors
        // for the inner classes are private.
        HeaderNavigationMenu.HomeImpl home = new HeaderNavigationMenu.HomeImpl();
        Console.ReadKey();
    }
}
public class HeaderNavigationMenu
{
    //Private factory methods that are statically initialized
    private static Func<UsersMenuImpl> _createUsers;
    private static Func<DropdownMenu2Impl> _createDropdown;
    private static Func<HomeImpl> _createHome;
    public HeaderNavigationMenu()
    {
        //Force the static constructors to run
        System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(UsersMenuImpl).TypeHandle);
        System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(HomeImpl).TypeHandle);
        System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(DropdownMenu2Impl).TypeHandle);
        UsersMenu = _createUsers();
        Home = _createHome();
        DropdownMenu2 = _createDropdown();
    }
    public UsersMenuImpl UsersMenu { get; set; }
    public HomeImpl Home { get; set; }
    public DropdownMenu2Impl DropdownMenu2 { get; set; }
    public class UsersMenuImpl
    {
        //Static constructor to make the class factory method
        static UsersMenuImpl()
        {
            _createUsers = () => new UsersMenuImpl();
        }
        private UsersMenuImpl() { }
    }
    public class HomeImpl
    {
        //Static constructor to make the class factory method
        static HomeImpl()
        {
            _createHome = () => new HomeImpl();
        }
        private HomeImpl() { }
    }
    public class DropdownMenu2Impl
    {
        //Static constructor to make the class factory method
        static DropdownMenu2Impl()
        {
            _createDropdown = () => new DropdownMenu2Impl();
        }
        private DropdownMenu2Impl() { }
        public void SelectOption3()
        {
        }
    }
}
With this, you will still be able to use all the public properties of the inner classes however no one will be able to instantiate the inner classes from outside `HeaderNavigationMenu` and only `HeaderNavigationMenu` has access to the factory methods.
