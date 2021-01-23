         static void Main(string[] args)
            {
                List<DateRange> range = new List<DateRange>();
    //temp filling the data
                DateTime start = new DateTime(2011, 4, 1);
                range.Add(new DateRange() {From=start,To = start.AddMonths(3).AddMilliseconds(-1),Name="Q1"});
                start = range.LastOrDefault().To.AddMilliseconds(1);
                range.Add(new DateRange() { From = start, To = start.AddMonths(3).AddMilliseconds(-1), Name = "Q2" });
                start = range.LastOrDefault().To.AddMilliseconds(1);
                range.Add(new DateRange() { From = start, To = start.AddMonths(3).AddMilliseconds(-1), Name = "Q3" });
                start = range.LastOrDefault().To.AddMilliseconds(1);
                range.Add(new DateRange() { From = start, To = start.AddMonths(3).AddMilliseconds(-1), Name = "Q4" });
    
                var order = range.OrderByDescending(r => r.IsCurrentQuater(DateTime.Now));
                foreach (var itm in order)
                    Console.WriteLine(itm);
    
            }
        }
    
        public class DateRange
        {
            public string Name { get; set; }
            public DateTime From { get; set; }
            public DateTime To { get; set; }
    
            public bool IsCurrentQuater(DateTime date)
            {
                return date >= From && date <= To;
            }
    
            public override string ToString()
            {
                return string.Format("{0} - {1} to {2}", Name, From, To);
            }
        }
