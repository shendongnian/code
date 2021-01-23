     //in Form2
    public delegate void PassValues(int a, string b, double c);
    public PassValues passVals;
    private void PassDataThroughDelegate(int a, string b, double c)
    {
        if(passVals != null)
            passVals(a,b,c);
    }
    //in Form1
    private void ShowForm(int a, string b, double c)
    {
        Form2 frm = new Form2();
        frm.passVals = new Form2.PassValues(UseData);
        frm.ShowDialog();
    }
    private void UseData(int a, string b, double c)
    {
    } 
