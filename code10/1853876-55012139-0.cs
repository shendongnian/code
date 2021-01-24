    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[i].Values[0]);
        string name = GridView1.DataKeys[i].Values[1].ToString();
    }
