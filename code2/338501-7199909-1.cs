    public class Stock 
    {
        private readonly IList<Price> _prices = new List<Price>();
        public string Symbol { get; set; }
        public string Name { get; set; }
        public IList<Price> Prices 
        {
            get { return _prices; }
        }
    }
