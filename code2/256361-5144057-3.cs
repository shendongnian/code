    //in the above Money class
    public static operator + (Money a, Money b)
    {
        if(a.Unit != b.Unit) throw new InvalidOperationException("Cannot perform arithmetic on Money of two different types.")
        //or, create some helper that will convert the second term
        //CurrencyConverter.Convert(b.Amount, b.Unit, a.Unit);
        return new Money{Amount = a.Amount + b.Amount, Unit = a.Unit};
    }
