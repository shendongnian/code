    private decimal n2;
    public decimal N2
    {
       get
       {
           return n2;
       }
       set
       {
           n2 = Convert.ToDecimal(value);
           OnPropertyChanged(n2);
       }
    }
