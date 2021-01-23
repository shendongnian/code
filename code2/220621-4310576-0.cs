    public class DataItem
    {
        public int First { get; set; }
        public int Second { get; set; }
    }
    public static void Main(string[] args)
    {
        List<DataItem> data = new List<DataItem>
            {
                new DataItem { First = 100, Second = 0 },
                new DataItem { First = 200, Second = 0 },
                new DataItem { First = 0, Second = 400 }
            };
        var result = data.Select((item, index) => new
            {
                First = item.First,
                Second = item.Second,
                Result = data.Take(index + 1).Sum(x => x.First - x.Second)
            });
    }
