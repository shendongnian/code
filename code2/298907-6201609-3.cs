    using System;
    using System.Web.Script.Serialization;
    
    public class MyDate
    {
        public int year;
        public int month;
        public int day;
    }
    
    public class Lad
    {
        public string firstName;
        public string lastName;
        public MyDate dateOfBirth;
    }
    
    class Program
    {
        static void Main()
        {
            var obj = new Lad
            {
                firstName = "Markoff",
                lastName = "Chaney",
                dateOfBirth = new MyDate
                {
                    year = 1901,
                    month = 4,
                    day = 30
                }
            };
            var json = new JavaScriptSerializer().Serialize(obj);
            Console.WriteLine(json);
        }
    }
