    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    namespace ConsoleApplication106
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>() {
                    new Student() { name = "AAA", dob = DateTime.ParseExact("10-05-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture), location = "Mumbai"},
                    new Student() { name = "BBB", dob = DateTime.ParseExact("05-02-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture), location = "Pune"},
                    new Student() { name = "CCC", dob = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture), location = "Delhi"},
                    new Student() { name = "DDD", dob = DateTime.ParseExact("20-03-1999", "dd-MM-yyyy", CultureInfo.InvariantCulture), location = "Lucknow"},
                    new Student() { name = "EEE", dob = DateTime.ParseExact("15-06-1999", "dd-MM-yyyy", CultureInfo.InvariantCulture), location = "Chennai"},
                    new Student() { name = "FFF", dob = DateTime.ParseExact("18-09-1999", "dd-MM-yyyy", CultureInfo.InvariantCulture), location = "Ahmedabad"}
                };
                var results = students.OrderByDescending(x => x.dob)  //sort from youngest to oldest
                    .GroupBy(x => x.dob.Year) //group by year
                    .Select(x => x.First())  //get first student born each year which is youngest
                    .ToList();
            }
     
        }
        public class Student
        {
            public DateTime dob { get; set; }
            public string name { get; set; }
            public string location { get; set;}
        }
    }
