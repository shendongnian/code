    protected void Button1_Click(object sender, EventArgs e)
    {
        BillOfLading newBol = new BillOfLading("AXSY1414114");
        bolList.Add(newBol);
    
        newBol = new BillOfLading("CRXY99991231");
        bolList.Add(newBol);
    }
