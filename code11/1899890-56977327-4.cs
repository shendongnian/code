        private ObservableCollection<Product> product;
        public ObservableCollection<Product> Product
        {
            get
            {
                return this.product;
            }
            set
            {
                if (this.product == value)
                    return;
                this.product = value;
                RaisePropertyChanged(nameof(this.Product));
                this.Product.CollectionChanged += CalculateTotalPriceOnCollectionChanged;
            }
        }
        private decimal totalPrice;
        public decimal TotalPrice
        {
            get
            {                
                return this.totalPrice;
            }
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
