        using (OleDbConnection sqlCon = new OleDbConnection(connectionStr))
        {
            sqlCon.Open();
            // get the goals from the web control
            string goalsText = (SoccerTable.Rows[e.RowIndex].FindControl("AchNums") as DropDownList).Text.Trim();
            // try to parse goals to int
            if (!int.TryParse(goalsText, out int goals))
            {
                // handle error
            }
            // try to parse user id to int
            if (!int.TryParse(SoccerTable.DataKeys[e.RowIndex].Value.ToString(), out int id))
            {
                // handle error
            }
            // increment the value in sql statement
            string query = "UPDATE SoccerAchievements SET Achievement = Achievement + @Goals WHERE UserID = @id";
            OleDbCommand sqlCmd = new OleDbCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@Goals", goals);
            sqlCmd.Parameters.AddWithValue("@id", id));
            sqlCmd.ExecuteNonQuery();
            lblSuccessMessage.Text = "עריכת הנתונים התבצעה בהצלחה";
            lblErrorMessage.Text = "";
        }
