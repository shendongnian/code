    public void TestClick(object sender, EventArgs e)
    {
        PropertyInfo prop_ID = e.GetType().GetProperty("ID");
    
        int id = Convert.toInt32(prop_ID.GetValue(e, null));
    }
