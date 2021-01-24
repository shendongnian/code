    public ViewModel()
    {
        this.PropertyChanged += async (s, e) =>
        {
            switch (e.PropertyName)
            {
                case nameof(DateDebut):
                    await GetParametresMatrice();
                    //here the method has completed and you can do whatever you want...
                    break;
            }
        };
    }
