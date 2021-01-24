    public class DataContextOfView 
    {
        private int _productQuantityStock;
        // Because you'll be working with values of type int you should make it an int
        public int ProductQuantityStock
        {
             get { return _productQuantityStock;}
             set { if(_productQuantityStock != value) 
                    { 
                     _productQuantityStock = value
                     // notify that the value of the property has changed.
                     OnPropertyChanged(nameof(ProductQuantityStock));
                    }
                 }
        }
    }
