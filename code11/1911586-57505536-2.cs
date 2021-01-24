    System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand( SET A OLEDBCONNECTION HERE );
    myCommand.CommandText = "INSERT INTO MASSNAHMEN (NAME, PROJEKTLEITER_AID, MASSNAHMENART_ID, UMSETZUNGSWEG, STATUS_ID, MASSNAHMENSTART, PAINPOINT, LOESUNG, BETEILIGTE_USER) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
    myCommand.Parameters.AddWithValue("", myNewMassnahme.Name); //This is a string
    myCommand.Parameters.AddWithValue("", myUser.myLoginUser._MySpAppS.Encrypt_AES(myNewMassnahme.Projektleiter.A_ID)); //this is a string
    myCommand.Parameters.AddWithValue("", myNewMassnahme.MassnahmenartID); //this is an int
    myCommand.Parameters.AddWithValue("", myNewMassnahme.Umsetzungsweg); //this is a string
    myCommand.Parameters.AddWithValue("", myNewMassnahme.Status_ID); //this is an int
    myCommand.Parameters.AddWithValue("", myNewMassnahme.Massnahmenstart); //this is a DateTime
    myCommand.Parameters.AddWithValue("", myNewMassnahme.Painpoint); //This is a string
    myCommand.Parameters.AddWithValue("", myNewMassnahme.Loesung); //This is a string
    myCommand.Parameters.AddWithValue("", myNewMassnahme.Beteiligte_User); //This is a string
    int numRecordsInserted = myCommand.ExecuteNonQuery();
