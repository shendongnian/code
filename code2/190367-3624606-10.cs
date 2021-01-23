    string sName = null;
    double? nAmount = null;
    foreach (Control ctl in this.flowLayoutPanel1.Controls) 
    {
       if (ctl.Name.Contains("tb") && ctl is TextBox) sName = ctl.Text;
       if (ctl.Name.Contains("bb") && ctl is TextBox) 
       {
           double nTmp = 0;
           if (double.TryParse(bbl.Text, out nTmp)) nAmount = nTmp;
       }
   
       if (sName != null && iAmount != null) 
       {
          SqlCommand cmd1 = new SqlCommand("INSERT INTO dummy (name, amount) VALUES (@name, @amount)", con);
          cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = sName;
          cmd1.Parameters.Add("@amount", SqlDbType.Decimal).Value = nAmount;
          cmd1.ExecuteNonQuery();
          sName = null;
          nAmount = null;
       }
    }
     
