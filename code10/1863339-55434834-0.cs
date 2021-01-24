    if you want to add row in Statistic  you have to pass id of player as a FK 
    just add this line to your code i hope it works
       newRow["PlayerID"] = int.parse(drpPlayer.selectedvalue);
    
    it will be :
    tblStatistic = (DataTable)Cache["tbl"];
    
                DataRow newRow = tblStatistic.NewRow();
                newRow["StatID"] = 0;
                newRow["PlayerID"] = int.parse(drpPlayer.selectedvalue);
                newRow["MatchesPlayed"] = txtMatchesPlayed.Text;
                newRow["MatchesWon"] = txtMatchesWon.Text;
                newRow["Assists"] = txtAssists.Text;
                newRow["Goals"] = txtGoals.Text;
                tblStatistic.Rows.Add(newRow);
    
    
    
                adapter.InsertCommand = cmdBuilder.GetInsertCommand();
                int rowsAffected = adapter.Update(tblStatistic);
    
                if (rowsAffected == 1)
                {
                    lblMessage.Text = "Stats inserted";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Stat not inserted";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
