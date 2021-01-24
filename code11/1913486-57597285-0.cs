    public void bttnSpeichern_Click_1(System.Object sender, EventArgs e)
    {
    	//Module.con.Open(); < -- Not needed it is done below
    
    	int geraetid = (int)(Conversion.Val(lblGeraetid.Text));
    	int bereichid = (int)(Conversion.Val(lblBereichID.Text));
    
    	if (lblGeraetid.Text == "MaschineID" || lblGeraetid.Text == null || txtGeraetName.Text == null || lblGeraetid.Text == "BereichID" || lblBereichID.Text == null)
    	{
    		Interaction.MsgBox("Bitte füllen Sie die Faldern aus", Constants.vbInformation, "Hinweis");
    	}
    	else
    	{
    		string b = System.Convert.ToString(Interaction.MsgBox("Möchten Sie die Eingaben bestätigen?", (int)Constants.vbQuestion + Constants.vbYesNo, "Anlegen"));
    		if ( b == Constants.vbYes.ToString())
    		{
    			string geraete_anlegen = new OleDbCommand("INSERT INTO tblMaschine(MaschineID,Maschine,BereichID) VALUES (\'"+
    			 lblGeraetid.Text + "\',\'"+
    			 txtGeraetName.Text + "\',\'" +
    			 lblBereichID.Text + "\',\'", Module.con);
    			using (OleDbConnection connection = new OleDbConnection(connectionString)) //<-You need to supply a connection string
    			{
    				connection.Open();
    				OleDbCommand command = new OleDbCommand(geraete_anlegen, connection);
    				command.ExecuteNonQuery();
    			}
    			
    			Interaction.MsgBox("Gerät wurde erfolgreich angelegt!", Constants.vbInformation, "Neues Gerät");
    			//clear_text();
    			Module.con.Close();
    			display_geraete();
    
    		}
    	}
    
    }
