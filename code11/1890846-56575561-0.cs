    public string Decimal
    {
        get { return Number.Decimal; }
        set
        {
            if (Number.Decimal != value)
            {
                Number.Decimal = value;
                RaisePropertyChanged(nameof(Decimal));
                RaisePropertyChanged(nameof(Dual));
                RaisePropertyChanged(nameof(Hexa));
                RaisePropertyChanged(nameof(Octa));
            }
        }
    }
