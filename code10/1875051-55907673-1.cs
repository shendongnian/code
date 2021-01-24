c#
  public class LeadPerformanceItem
    {
        public string name { get; set; }
        public int Visitors { get; set; }
        private int _totalVisitors = 0;
        public void UpdateTotalVisitors(int total)
        {
            this._totalVisitors = total;
        }
        public decimal Visitorspercentoftotal => _totalVisitors != 0
            ? Convert.ToDecimal(Math.Round(((double) (Visitors * 100)) / _totalVisitors))
            : 0;
    }
    public class LeadPerformanceItemCollection
    {
        public List<LeadPerformanceItem> Items { get; set; }
        public void AddToItems(LeadPerformanceItem item)
        {
            Items.Add(item);
            var total = Items.Sum(x => x.Visitors);
            Items.AsParallel().ForAll(i => i.UpdateTotalVisitors(total));
        }
        public int totalvisitors
        {
            get { return Items.Sum(x => x.Visitors); }
        }
    }
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            var leadPerformanceItemCollection = new LeadPerformanceItemCollection();
            leadPerformanceItemCollection.Items=new List<LeadPerformanceItem>();
            leadPerformanceItemCollection.AddToItems(new LeadPerformanceItem()
            {
                name = "test",
                Visitors = 10
            });
            leadPerformanceItemCollection.AddToItems(new LeadPerformanceItem()
            {
                name = "test2",
                Visitors = 25
            });
            
            Console.WriteLine(leadPerformanceItemCollection.Items[0].Visitorspercentoftotal);
            Console.WriteLine(leadPerformanceItemCollection.Items[1].Visitorspercentoftotal);
            
        }
    }
result:
29%
71%
