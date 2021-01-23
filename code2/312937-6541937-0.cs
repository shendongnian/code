    public class ListActiveLogins
    {
        public static Process[] ActiveLogins;
        public ListActiveLogins(int loginCount)
        {
            ActiveLogins = new Process[loginCount];
        }
