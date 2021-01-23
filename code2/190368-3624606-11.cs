    StringBuilder sb = null;
    sb = new StringBuilder();
    sb.Append("insert into dummy(name,amount)values (");
    foreach (Control ctl in this.flowLayoutPanel1.Controls) 
    {
       if (ctl.Name.Contains("tb") && ctl is TextBox) 
       {
          sb.Append("'" + ctl.Text + "'");
       }
    } 
    sb.Append(", ");
    foreach(Control bbl in this.flowLayoutPanel1.Controls)
    {
       if(bbl.Name.Contains("bb") && bbl is TextBox)
       {
           sb.Append(bbl.Text);
       }
    }
    sb.Append(")");
    SqlCommand cmd1 = new SqlCommand(sb.ToString(), con);
    cmd1.CommandType = CommandType.Text;
    cmd1.ExecuteNonQuery();
