    using (var myConnection = new SqlConnection(strConnection))
    using (var myCommand = myConnection.CreateCommand())
    {
        myCommand.CommandText = "UPDATE fstage.staticCMS SET About = @AboutText";
        myCommand.Parameters.AddWithValue("AboutText", txtAbout.Text);
        myConnection.Open();
        myCommand.ExecuteNonQuery();
    }
