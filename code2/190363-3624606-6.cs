    string sName = "";
    int iAmount = 0;
    foreach (Control ctl in this.flowLayoutPanel1.Controls) 
    {
       if (ctl.Name.Contains("tb") && ctl is TextBox) 
       {
          sName = ctl.Text;
          break;
       }
    } 
    foreach(Control bbl in this.flowLayoutPanel1.Controls)
    {
       if(bbl.Name.Contains("bb") && bbl is TextBox)
       {
           Int.TryParse(bbl.Text, out iAmount);
           break;
       }
    }
    SqlCommand cmd1 = new SqlCommand("INSERT INTO dummy (name, amount) VALUES (@name, @amount)", con);
    cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = sName;
    cmd1.Parameters.Add("@amount", SqlDbType.Int).Value = iAmount;
    cmd1.ExecuteNonQuery();
