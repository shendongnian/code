    public class OrderViewModel : ViewModelBase
    {
      private decimal _totalPrice;
      public decimal TotalPrice
      {
        get => this._totalPrice;
        set
        {
          if (this._totalPrice == value)
            return;
          this._totalPrice = value;
    
          RaisePropertyChanged();
        }
      }
    
      private ObservableCollection<Product> _products;
      public ObservableCollection<Product> Products
      {
        get => this._products;
        set
        {    
          if (this.Products == value)
            return;
          if (this.Products != null)
          {
            this.Products.CollectionChanged -= OnCollectionChanged;
            UnsubscribeFromItemsPropertyChanged(this.Products);
          }
    
          this._products = value;
    
          this.Products.CollectionChanged += OnCollectionChanged;
          if (this.Products.Any())
          {
            SubscribeToItemsPropertyChanged(this.Products);
          }
    
          RaisePropertyChanged();
        }
      }
    
      private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
      {
        if (!e.Action.Equals(NotifyCollectionChangedAction.Move))
        {
          UnsubscribeFromItemsPropertyChanged(e.OldItems);
          SubscribeToItemsPropertyChanged(e.NewItems);
        }
    
        CalculateTotalPrice();
      }
    
      private void ProductChanged(object sender, PropertyChangedEventArgs e) => CalculateTotalPrice();
    
      private void SubscribeToItemsPropertyChanged(IList newItems) => newItems?.OfType<INotifyPropertyChanged>().ToList().ForEach((item => item.PropertyChanged += ProductChanged));
    
      private void UnsubscribeFromItemsPropertyChanged(IEnumerable oldItems) => oldItems?.OfType<INotifyPropertyChanged>().ToList().ForEach((item => item.PropertyChanged -= ProductChanged));
    
      private void CalculateTotalPrice() => this.TotalPrice = this.Products.Sum(item => item.total_price);
    
      private void GetProducts()
      {
        using (var context = new mainEntities())
        {
          var result = context.product.Include(c => c.brand);
          this.Products = new ObservableCollection<Product>(
            result.Select(item => new Product(item.name, item.mass, item.ean, item.brand.name, item.price)));
        }
      }
    
      public void ResetOrder()
      {
        this.Products
          .ToList()
          .ForEach(product => product.Reset());
      }
    
      public OrderViewModel()
      {
        SetView("Dodaj zamówienie");
        GetProducts();
      }
    }
