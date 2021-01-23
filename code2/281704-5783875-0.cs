    public abstract class ClassBase : INotifyPropertyChanged
    {
        private string productType;
        private string colorProductType;
    
        public ClassBase()
        {
            this.PropertyChanged += HandlePropertyChanged;
        }
    
        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "ProductType")
            {
                // update ColorProductType here
            }
        }
    
        private void RaisePropertyChanged(string propertyName)
        {
            if ( PropertyChanged != null )
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public string ProductType
        {
            get { return productType; }
            set
            {
                if ( productType == value )
                    return;
    
                productType = value;
                RaisePropertyChanged("ProductType");
            }
        }
    
        public string ColorProductType
        {
            get { return colorProductType ; }
            set
            {
                if (colorProductType == value)
                    return;
    
                colorProductType = value;
                RaisePropertyChanged("ColorProductType");
            }
        }
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        #endregion
    }
