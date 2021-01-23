    void Main()
    {
    	Console.WriteLine(DateTime.Now.MyCustomToString());
    }
    
    // Define other methods and classes here
    public static class DateTimeExtensions
    {
        public static string MyCustomToString(this DateTime dt)
        {
            return string.Format("{0} {1}", DateTime.Now.ToString("ddd MMM dd yyyy HH:mm tt"), TimeZone.CurrentTimeZone.StandardName).Replace(" Standard Time", string.Empty);
        }
    }
