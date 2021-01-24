    private Form custForm;
    private void LoadCity_Click(object sender, EventArgs e)   
    {
        if(custForm == null)
        {
            custform = new Clothes(); //Clothes should be a Form
        }
        List cust = new List();
        for(int i = 0; i < _Mexico.Count; i++)
        {
            cust.add(_Mexico.ElementAt(i);
        }
        custform.CustomersList = cust;
    }
