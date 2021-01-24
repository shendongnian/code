    class MainWindowVm : ViewModel
    {
        public MainWindowVm()
        {
            var rnd = new Random();
            Prices = new ObservableCollection<PriceEntryVm>();
            for (int i = 0; i < 8; i++)
            {
                var entry = new PriceEntryVm();
                Prices.Add(entry);
                entry.BuyOrders.CollectionChanged += OnOrderChanged;
                entry.SellOrders.CollectionChanged += OnOrderChanged;
                entry.Price = (decimal)110.91 + (decimal)i / 100;
                var numBuy = rnd.Next(5);
                for (int orderIndex = 0; orderIndex < numBuy; orderIndex++)
                {
                    var order = new OrderVm();
                    order.Qty = rnd.Next(70) + 5;
                    entry.BuyOrders.Add(order);
                }
                var numSell = rnd.Next(5);
                for (int orderIOndex = 0; orderIOndex < numSell; orderIOndex++)
                {
                    var order = new OrderVm();
                    order.Qty = rnd.Next(70) + 5;
                    entry.SellOrders.Add(order);
                }
            }
        }
        private void OnOrderChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    var order = item as OrderVm;
                    if (order.Qty > LargestOrder)
                    {
                        LargestOrder = order.Qty;
                    }
                }
            }
        }
        private int _largestOrder;
        public int LargestOrder
        {
            get { return _largestOrder; }
            private set { SetValue(ref _largestOrder, value); }
        }
        public ObservableCollection<PriceEntryVm> Prices { get; }
    }
    public class PriceEntryVm: ViewModel
    {
        public PriceEntryVm()
        {
            BuyOrders = new OrderList(this);
            SellOrders = new OrderList(this);
        }
        private Decimal _price;
        public Decimal Price
        {
            get {return _price;}
            set {SetValue(ref _price, value);}
        }
        public OrderList BuyOrders { get; }
        public OrderList SellOrders { get; }
    }
    public class OrderList : ObservableCollection<OrderVm>
    {
        public OrderList(PriceEntryVm priceEntry)
        {
            PriceEntry = priceEntry;
        }
        public PriceEntryVm PriceEntry { get; }
    }
    public class OrderVm : ViewModel
    {
        private int _qty;
        public int Qty
        {
            get { return _qty; }
            set { SetValue(ref _qty, value); }
        }
    }
