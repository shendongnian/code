    public interface IDisplayType
    {
        string backgroundColor { get; }
    }
    public class AdminPage : IDisplayType
    {
        public string backgroundColor { get { return "orange"; } }
    }
    public class UserPage : IDisplayType
    {
        public string backgroundColor { get { return "blue"; } }
    }
    public static class PageProperties
    {
        private static AdminPage _adminPage = new AdminPage();
        private static UserPage _userPage = new UserPage();
        public static IDisplayType DisplayType { get
        {
            if ((bool)HttpContext.Current.Session["Is_Admin"])
             {
                return _adminPage;
             }
            return _userPage;
        }
     }
