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
            this.TotalPrice = 0;
            foreach (var item in this.Products)
            {
                item.TotalPrice = item.Amount * item.Price;
                this.TotalPrice += item.TotalPrice;
            }
        }
