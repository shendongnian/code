    using System;
    namespace ConsoleApp1
    {
    class Program
    {
        static void Main(string[] args)
        {
            string getdate = "1970-11-28T11:00:00.000-0500";
      
            var dt = DateTime.Parse(getdate).ToLocalTime();
            string s = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); //1970-11-28
        }
    }
    }
