    static void Main(string[] args)
            {
                var date1 = new DateTime(2018, 12, 05);
                var date2 = new DateTime(2019, 03, 01);
    
                int CountNumberOfMonths() => (date2.Month - date1.Month) + 12 * (date2.Year - date1.Year);
    
                var numberOfMonths = CountNumberOfMonths();
    
                Console.WriteLine("Number of months between {0} and {1}: {2} months.", date1.ToString(), date2.ToString(), numberOfMonths.ToString());
    
                Console.ReadKey();
    
                //
                // *** Console Output:
                // Number of months between 05/12/2018 00:00:00 and 01/03/2019 00:00:00: 3 months.
                //
    
            }
