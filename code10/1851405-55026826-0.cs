private void BindGrid()
{
    DataTable dt = new DataTable();
    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
    MySqlConnection con = new MySqlConnection(strConnString);
    MySqlDataAdapter sda = new MySqlDataAdapter();
    MySqlCommand cmd = new MySqlCommand("GetTMData");
    cmd.CommandType = CommandType.StoredProcedure;  
    string statusVal = null;
     foreach (ListItem item in ddlstatus.Items)
     {
        if(item.Selected)
        {
           if(statusVal.length > 0)
               statusVal += ",";
           statusVal += item.Value;
        }
     }
    cmd.Parameters.AddWithValue("statusVal", statusVal);
    cmd.Connection = con;
    sda.SelectCommand = cmd;
    sda.Fill(dt);
    gdvTM.DataSource = dt;
    gdvTM.DataBind();
}
protected void DropDownChange(object sender, EventArgs e)
 {
      this.BindGrid();
 }
