    void Main()
    {
        var = new List<DateRange>();
        var dr = new DateRange(new DateTime(2019, 1, 1),new DateTime(2019, 2, 1),10);
        lst.Add(dr);
        dr = new DateRange(new DateTime(2019, 2, 2), new DateTime(2019, 3, 1), 11);
        lst.Add(dr);
        dr = new DateRange(new DateTime(2019, 3, 2), new DateTime(2019, 4, 1), 12);
        lst.Add(dr);
        var searchFor = new DateTime(2019, 2, 9);
        var res = (from x in lst
                  where x.DateFrm <= searchFor
                     && searchFor <= x.DateTo
                 select x.IValue).Single();
        Console.WriteLine($"result:{res}");
    }
    public class DateRange
    {
        public DateTime DateFrm { get; set; }
        public DateTime DateTo  { get; set; }
        public int      IValue  { get; set; }
        public DateRange(DateTime dateFrm, DateTime dateTo, int iValue)
        {
            DateFrm = dateFrm;
            DateTo  = dateTo;
            IValue  = iValue;
        }
    }
