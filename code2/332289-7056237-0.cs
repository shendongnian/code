    private FormA parentFormA;
    
    public FormB(FormA myFormA)
    {
        parentFormA = myFormA;
    }
    
    Private void FormB_FormClosing(object sender, FormClosingEventArgs e)
    {
        //parentFormA.UpdateCityData(parameter)
    }
