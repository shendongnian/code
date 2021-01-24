    DataTable dt = new DataTable();
    con.Open();
    string TeamID = (string)Session["TeamID"];
    SqlDataReader myReader = null;
    SqlCommand myCommand = new SqlCommand("SELECT * FROM Players1 WHERE 
    TeamID = " + teamID, con);
    myCommand.Parameters.AddWithValue("@TeamID", TeamID);
    myReader = myCommand.ExecuteReader();
    while (myReader.Read())
    {
        foreach (Object ob in myReader)
        {
            Button btn = new Button();
            btn.ID = "Btn_" + ob["Id"]; //I assume the table has an Id
            btn.Text = ob["Name"]; //I also assume the table has a Name column
            //for click events
            //btn.Click = btn_Click_Event; 
        }
    }
 
