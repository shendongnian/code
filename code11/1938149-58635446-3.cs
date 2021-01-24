    // Usage
    var answer = cards
        .GroupBy(c => c.Name)
        .SelectMany(ToDiffs)
        .ToList(); // A list of DiffCards
    // or maybe?
    var answer =
        from card in cards
        group card by card.Name into siteGroup
        let o = siteGroup.ElementAt(0)
        let t = siteGroup.ElementAt(1)
        select new List<DiffCard> { new DiffCard(o, t), new DiffCard(t, o) } into diffs
        from diff in diffs
        select diff;
    public class DiffCard
    {
        public string Name { get; set; }
        public decimal TradePrice { get; set; }
        public decimal Price { get; set; }
        public decimal Diff => Math.Abs(TradePrice - Price);
        public DiffCard(Card one, Card two)
        {
            Name = one.Name;
            TradePrice = one.TradePrice;
            Price = two.Price;
        }
    }
    IEnumerable<DiffCard> ToDiffs(IGrouping<string, Card> group)
    {
        var one = group.ElementAt(0);
        var two = group.ElementAt(1);
        var diffs = new List<DiffCard>
        {
            new DiffCard(one, two),
            new DiffCard(two, one)
        };
        foreach (var diff in diffs)
        {
            yield return diff;
        }
    }
