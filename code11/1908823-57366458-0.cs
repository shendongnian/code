    sing System;
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
                    new Payment(29, new DateTime(2019, 7, 10), "cash")
                };
                var results = allPayments
                    .GroupBy(x => new { type = x.PaymentType, month = new DateTime(x.PaymentDate.Year, x.PaymentDate.Month, 1) })
                    .ToList();
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
