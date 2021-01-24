    public class Product : ViewModelBase
    {
      public long id { get; set; }
      public string name { get; set; }
      public decimal mass { get; set; }
      public long ean { get; set; }
      public long brand_id { get; set; }
      public string img_source { get; set; }
      public string brand_name { get; set; }
    
      private decimal _price;
      public decimal price
      {
        get => this._price;
        set
        {
          if (this._price == value)
            return;
    
          this._price = value;
          RaisePropertyChanged();
          OnPriceChanged();
        }
      }
    
      private long _amount;
      public long amount
      {
        get => this._amount;
        set
        {
          if (this._amount == value)
            return;
    
          this._amount = value;
          RaisePropertyChanged();
          OnAmountChanged();
        }
      }
    
      private decimal _total_price;
      public decimal total_price
      {
        get => this._total_price;
        set
        {
          if (this._total_price == value)
            return;
    
          this._total_price = value;
          RaisePropertyChanged();
        }
      }
    
      public Product(long id, string name, decimal mass, long ean, long brandId, decimal price, string imgSource)
      {
        this.id = id;
        this.name = name;
        this.mass = mass;
        this.ean = ean;
        this.brand_id = brandId;
        this.price = price;
        this.img_source = imgSource;
      }
    
      public Product(string name, decimal mass, long ean, string brandName, decimal price)
      {
        this.id = this.id;
        this.name = name;
        this.mass = mass;
        this.ean = ean;
        this.brand_name = brandName;
        this.price = price;
      }
    
      public void Reset()
      {
        // Resetting the `amount` will trigger recalculation of `total_price`
        this.amount = 0;
      }
    
      protected virtual void OnAmountChanged()
      {
        CalculateTotalPrice();
      }
    
      private void OnPriceChanged()
      {
        CalculateTotalPrice();
      }
    
      private void CalculateTotalPrice()
      {
        this.total_price = this.price * this.amount;
      }
    }
