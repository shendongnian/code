    string sName = "";
    int iAmount = 0;
    foreach (Control ctl in this.flowLayoutPanel1.Controls) 
    {
       if (ctl.Name.Contains("tb") && ctl is TextBox) 
       {
          sName = ctl.Text;
       }
    } 
    foreach(Control bbl in this.flowLayoutPanel1.Controls)
    {
       if(bbl.Name.Contains("bb") && bbl is TextBox)
       {
           Int.TryParse(bbl.Text, out iAmount);
       }
    }
    SqlCommand cmd1 = new SqlCommand("INSERT INTO dummy (name, amount) VALUES (@name, @amount)", con);
    SqlParameter param1 = new SqlParameter();
    param1.ParameterName = "@name";
    param1.Value = sName;
    cmd1.Parameters.Add(param1);
    SqlParameter param2 = new SqlParameter();
    param2.ParameterName = "@amount";
    param2.Value = iAmount;
    cmd1.Parameters.Add(param2);
    cmd1.ExecuteNonQuery();
