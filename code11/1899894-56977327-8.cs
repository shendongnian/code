        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get => return this.products;
            set
            {
                if (this.products == value)
                    return;
                this.products = value;
                RaisePropertyChanged(nameof(this.Products));
                this.Products.CollectionChanged += CalculateTotalPriceOnCollectionChanged;
            }
        }
        private decimal totalPrice;
        public decimal TotalPrice
        {
            get => return this.totalPrice;
            set
            {
                if (this.totalPrice == value)
                    return;
                this.totalPrice = value;
                RaisePropertyChanged(nameof(this.TotalPrice));
            }
        }
        
        private void CalculateTotalPriceOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CalculateTotalPrice();
        } 
        private void CalculateTotalPrice()
        {
            foreach (var item in Products)
            {
                item.total_price = item.amount * item.price;
                this.TotalPrice += item.price * item.amount;
            }
        }
