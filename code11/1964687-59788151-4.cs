    public object SelectedProduct
        {
          get
          {
            return ProductList.SelectedItem;
          }
          set
          {
            ProductList.SelectedItem = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedProduct)));
          }
        }
