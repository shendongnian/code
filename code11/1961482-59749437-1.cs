    public class FilterWindowViewModel 
    {
      private string _product;
      public string Product
      {
        get => _product; 
        set
        {
          if (_product == value)
            return;
          _product = value;
       
          chkProduct = !string.IsNullOrWhiteSpace(value);
          OnPropertyChanged();
        }
      }
    }
