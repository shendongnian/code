    internal IEnumerable<string> Validate()
    {
        if( _customer.Age > 5 ) { yeild return "Too Old"; }
        if( _customer.Name.Length < 3 ) { yeild return "Not enough name characters"; }
    }
    // using it
    IEnumerable<string> errors = myCustomer.Validate();
    if( errors.Length > 0 ) {
        // uh oh, print out the errors!
        foreach( string error in errors ) {
            MsgBox(error);
        }
    }
