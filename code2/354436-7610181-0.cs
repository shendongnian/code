    public bool IsButtonEnabled
    {
        get
        {
            return MyList.Any(x=> x.FooProp!=null);
      
            // assuming you named the method this
            OnPropertyChanged("IsButtonEnabled");
        }
    }
