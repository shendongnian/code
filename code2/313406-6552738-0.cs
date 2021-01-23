    public void DoSomething (TOther thatBar)
    {
        var props = typeof (TOther).GetProperties();
        var foo = Items
            .Select (item => item.Bar)
            .Single (bar =>
                props.All (prop =>
                    prop.GetValue (thisBar, null).EqualsTo (
                       prop.GetValue (thatBar, null)
                    )
                )
            );
    
    }
