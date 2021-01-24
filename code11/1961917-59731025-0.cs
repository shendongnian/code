    public class PricingData : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            ......
    
            public string DisplayPricing
            {
                get => $"{PricingValue} {PricingCurrency}";
                set
                {
                    var sp = value.Split(' ');
                    PricingValue = sp.First();
                    PricingCurrency = sp.Last();
                    OnPropertyChanged();
                }
            }
    
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
