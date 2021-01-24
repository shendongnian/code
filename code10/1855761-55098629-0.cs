    public class MonthlyTrigger
    {
        [Flags] // Important because we want to set multiple values to this type
        public enum MonthOfYear
        {
            Jan = 1, // 1st bit
            Feb = 2, // 2nd bit..
            Mar = 4,
            Apr = 8,
            May = 16,
            Jun = 32,
            Jul = 64,
            Aug = 128,
            Sep = 256,
            Oct = 512,
            Nov = 1024,
            Dec = 2048
        }
        public HashSet<int> Months { get; set; } = new HashSet<int>(); // classical list to check months
        public MonthOfYear MonthFlag { get; set; } // out new type
    }
    public static void Main(string[] args)
    {
        MonthlyTrigger mt = new MonthlyTrigger();
        string monthsFromFileOrSomething = "1,3,5,7,9,11"; // fake some string..
        IEnumerable<int> splittedMonths = monthsFromFileOrSomething.Split(',').Select(s => Convert.ToInt32(s)); // split to values and convert to integers
        foreach (int month in splittedMonths)
        {
            mt.Months.Add(month); // adding to list (hashset)
            // Here we "add" another month to our Month-Flag => "Flag = Flag | Month"
            MonthlyTrigger.MonthOfYear m = (MonthlyTrigger.MonthOfYear)Convert.ToInt32(Math.Pow(2, month - 1));
            mt.MonthFlag |= m;
        }
        Console.WriteLine(String.Join(", ", mt.Months)); // let's see our list
        Console.WriteLine(mt.MonthFlag); // what is contained in our flag?
        Console.WriteLine(Convert.ToString((int)mt.MonthFlag, 2)); // how is it binarily-stored?
        // Or if you like it in one row:
        mt.MonthFlag = 0;
        foreach (MonthlyTrigger.MonthOfYear m in monthsFromFileOrSomething.Split(',').Select(s => (MonthlyTrigger.MonthOfYear)Convert.ToInt32(s)))
            mt.MonthFlag = m;
        return;
    }
