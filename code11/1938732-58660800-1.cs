        static void Main(string[] args)
        {
            string strdatetime = "2019-09-23T08:34:00UTC+1";
            DateTime dateTime = ParseDate(strdatetime.Replace("UTC+1",""));
            Console.WriteLine(dateTime);
        }
