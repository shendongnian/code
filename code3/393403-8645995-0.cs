    string query = "UPDATE User_Info SET ";
    foreach (Control ctl in panel.Controls)
    {
        if (ctl.Type == "Textbox")
        {
            query += ctl.Tag + " = " + "@" + ctl.Tag //assuming you preload the table names on the tags of the controls and you wanna name the parameters like that
            cmd.Parameters.AddWithValue("@" + ctl.Tag, ctl.Text);
            query += ", "
        }
     }
     //You need here something to eliminate the last comma
     query += "WHERE UserName =@username"
     cmd.Parameters.AddWithValue("@username", _usrName);
