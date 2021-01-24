    // Usage
    var answer = cards
        .GroupBy(c => c.Name)
        .SelectMany(ToDiffs)
        .ToList(); // A list of DiffCards
    // or maybe?
    var answer =
        from c in cards
        group c by c.Name into g
        from d in ToDiffs(g)
        select d;
    public class DiffCard
    {
        public string Name { get; set; }
        public decimal TradePrice { get; set; }
        public decimal Price { get; set; }
        public decimal Diff { get; set; }
    }
    IEnumerable<DiffCard> ToDiffs(IGrouping<string, Card> group)
    {
        var one = group.ElementAt(0);
        var two = group.ElementAt(1);
        var diffs = new List<DiffCard>
        {
            new DiffCard
            {
                Name = one.Name,
                TradePrice = one.TradePrice,
                Price = two.Price,
                Diff = Math.Abs(one.TradePrice - two.Price)
            },
            new DiffCard
            {
                Name = two.Name,
                TradePrice = two.TradePrice,
                Price = one.Price,
                Diff = Math.Abs(two.TradePrice - one.Price)
            }
        };
        foreach(var diff in diffs)
        {
            yield return diff;
        }
    }
