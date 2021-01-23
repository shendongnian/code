    class Basket
    {
        public Basket()
        {
            BasketInfos = new List<BasketInfo>();
        }
        public double GlobalWeight
        {
            get
            {
                return BasketInfos.Sum(x => x.LocalWeight); 
            }
        }
        public IList<BasketInfo> BasketInfos { get; set; }
    }
    class BasketInfo
    {
        public string Name { get; set; }
        public double Level1 { get; set; }
        public double Level2 { get; set; }
        public double LocalWeight { get; set; }
    }
    var baskets = new List<Basket>();
