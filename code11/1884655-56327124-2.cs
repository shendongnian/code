    string connectionString = @"Data Source= (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|BazaPRO2.mdf;Integrated Security=True;Connect Timeout=30";
    SqlConnection dataConnection = new SqlConnection(connectionString);
    dataConnection.Open();
    string q = "INSERT INTO Sola(SolaID,Naziv,Naslov,Kraj,Posta,Telefon,Eposta) VALUES(1,'Test','Test','Test',1000,'Test','Test')";
    using(SqlCommand dataCommand = new SqlCommand(q, dataConnection))
    {
        try
        {
            dataCommand.ExecuteNonQuery();
            Console.WriteLine("Success");
        }
        catch { Console.WriteLine("Fail"); }
    }
    dataConnection.Close();
