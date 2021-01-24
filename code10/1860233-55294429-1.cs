    public class CustomNavigationPage : NavigationPage
    {
       public static IContainer Container;
       public CustomNavigationPage()
       {
           Locator locator = new Locator();
           locator.RegisterTypes();
           Container = locator.Container();
       }
    }
