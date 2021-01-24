   from payment3 in (
      from pay2 in TypedYearBracket
      group pay2 by pay2.PaymentDate.Month into MonthBracket
      select MonthBracket
   )
   select payment3
was causing an issue with the grouping and pretty much erasing my attempt to group by Year.
I then realized that the last group by of the entire LINQ section (```group payment2 by TypeBracket.Key;``` was re-applying the Type grouping to the results of the inner groups. This led me to realize that instead of ```select payment3```; I needed ```group payment3 by TypedYearBracket.Key``` to re-apply the Year grouping to the Month sub-grouping results.
This ends up making the code: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Payment> allPayments = new List<Payment>()
            {
                new Payment(25, new DateTime(2019, 8, 5), "web CC"),
                new Payment(26, new DateTime(2019, 8, 5), "cash"),
                new Payment(27, new DateTime(2019, 8, 5), "cash"),
                new Payment(28, new DateTime(2019, 8, 5), "check"),
                new Payment(29, new DateTime(2019, 7, 10), "cash"),
                new Payment(0, new DateTime(2000, 8, 10), "cash")
            };
           var ranges = new List<String> { "Cash", "Check", "Money Order", "Web CC" };
           var results = from payment in allPayments
                         let match = ranges.FirstOrDefault(range => range.Equals(payment.PaymentType, StringComparison.OrdinalIgnoreCase))
                         group payment by !String.IsNullOrEmpty(match) ? match : "Other" into TypeBracket
                         from payment2 in (
                            from pay in TypeBracket
                            group pay by pay.PaymentDate.Year into TypedYearBracket
                            from payment3 in (
                                  from pay2 in TypedYearBracket
                                  group pay2 by pay2.PaymentDate.Month into MonthBracket
                                  select MonthBracket
                            )
                            group payment3 by TypedYearBracket.Key
                         )
                         group payment2 by TypeBracket.Key;
            foreach (var x in results)
            {
                Console.WriteLine("1st Level: {0} - {1}", x.Key, x.Count());
                foreach (var y in x)
                {
                    Console.WriteLine("   2nd Level: {0} - {1}", y.Key, y.Count());
                    foreach (var z in y)
                    {
                        Console.WriteLine("      3rd Level: {0} - {1}", z.Key, z.Count());
                        foreach (var a in z)
                        {
                            Console.WriteLine("         Details: Type: {0}, Year: {1}, Month: {2}, ID: {3}", a.PaymentType, a.PaymentDate.Year, a.PaymentDate.Month, a.PaymentId);
                        }
                    }
                }
        }
    }
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public String PaymentType { get; set; }
        public Payment(int id, DateTime date, string type)
        {
            PaymentId = id;
            PaymentDate = date;
            PaymentType = type;
        }
    }
}
This gives the desired result of:
1st Level: Web CC - 1
   2nd Level: 2019 - 1
      3rd Level: 8 - 1
         Details: Type: web CC, Year: 2019, Month: 8, ID: 25
1st Level: Cash - 2
   2nd Level: 2019 - 2
      3rd Level: 8 - 2
         Details: Type: cash, Year: 2019, Month: 8, ID: 26
         Details: Type: cash, Year: 2019, Month: 8, ID: 27
      3rd Level: 7 - 1
         Details: Type: cash, Year: 2019, Month: 7, ID: 29
   2nd Level: 2000 - 1
      3rd Level: 8 - 1
         Details: Type: cash, Year: 2000, Month: 8, ID: 0
1st Level: Check - 1
   2nd Level: 2019 - 1
      3rd Level: 8 - 1
         Details: Type: check, Year: 2019, Month: 8, ID: 28
