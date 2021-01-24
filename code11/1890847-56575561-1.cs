    private void NumbersChanged()
    {
        RaisePropertyChanged(nameof(Decimal));
        RaisePropertyChanged(nameof(Dual));
        RaisePropertyChanged(nameof(Hexa));
        RaisePropertyChanged(nameof(Octa));
    }
    public string Decimal
    {
        get { return Number.Decimal; }
        set
        {
            if (Number.Decimal != value)
            {
                Number.Decimal = value;
                NumbersChanged();
            }
        }
    }
    public string Hexa
    {
        get { return Number.Hexa; }
        set
        {
            if (Number.Hexa != value)
            {
                Number.Hexa = value;
                NumbersChanged();
            }
        }
    }
    //etc...
