    protected void btnDelete_DataBinding(object sender, System.EventArgs e)
    {
        Button btn = (Button)(sender);
        btn.Enabled = !Eval("TheFieldInYourDataSourceToCompare").ToString.Equals("NA");
    }
