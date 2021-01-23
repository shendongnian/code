    public void ErrorDBConcurrency(DBConcurrencyException e, Action method)
    {
        if (MessageBox.Show("You must refresh the datasource") == DialogResult.OK)
            method()
    }
    
    public void Method()
    {
    	// do stuff
    }
    //....
