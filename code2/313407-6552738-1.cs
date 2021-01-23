    static readonly otherProps = typeof (TOther).GetProperties();
    public void DoSomething (TOther thatBar)
    {
        var foo = Items
            .Select (item => item.Bar)
            .Single (bar =>
                otherProps.All (prop =>
                    prop.GetValue (thisBar, null).Equals (
                       prop.GetValue (thatBar, null)
                    )
                )
            );
    
    }
