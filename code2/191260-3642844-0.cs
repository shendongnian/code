    public event PropertyChangedEventHandler PropertyChanged {
        add {
            propertyChangedHelper.PropertyChanged += value;
        }
        remove {
            propertyChangedHelper.PropertyChanged -= value;
        }
    }
