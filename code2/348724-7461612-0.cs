    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
      public class Customer
      {
         public int CutIND { get; set; }
         public string CustName { get; set; }
         public string Country { get; set; }
         public string City { get; set; }
         public string Area { get; set; }
         public string Gender { get; set; }
         public int plusMinus { get; set; }
         public Customer(int CutIND, string CustName, string Country, string City, string Area, string Gender, int plusMinus)
         {
            this.CutIND = CutIND;
            this.CustName = CustName;
            this.Country = Country;
            this.City = City;
            this.Area = Area;
            this.Gender = Gender;
            this.plusMinus = plusMinus;
         }
      }
      class Program
      {
         static void Main(string[] args)
         {
            Customer[] customers = new Customer[] {
               new Customer(123445, "Sajjad", "US", "NYC", "BLueArea", "M", -560),
               new Customer(43432, "Mike", "UK", "London", "someArea", "M", 9000),
               new Customer(20001, "Mathilde", "OS", "Vienna", "WienerWald", "F", 8192),
               new Customer(20002, "Harry", "US", "NYC", "Broooklyn", "M", 50),
               new Customer(20003, "Jim", "OS", "Vienna", "AIS", "M", 12000),
               new Customer(20004, "Bill", "US", "MSP", "Excelsior", "M", 90)
            };
            var CityGroups =
               from c in customers
               group c by new { Country = c.Country, City = c.City } into cities
               select new { Country = cities.Key.Country, City = cities.Key.City, Total = cities.Sum(c => c.plusMinus), Residents = cities };
            var CountryGroups =
               from city in CityGroups
               group city by city.Country into countries
               select new { Country = countries.Key, Cities = countries, Total = countries.Sum(c => c.Total) };
            foreach (var country in CountryGroups)
            {
               Console.WriteLine("{0} (Total = {1})", country.Country, country.Total);
               foreach (var city in country.Cities)
               {
                  Console.WriteLine("  {0} (Total = {1})", city.City, city.Total);
                  foreach (var r in city.Residents)
                  {
                     Console.WriteLine("    {0} {1} {2} {3}", r.Area, r.CustName, r.Gender, r.plusMinus);
                  }
               }
            }
         }
      }
    }
