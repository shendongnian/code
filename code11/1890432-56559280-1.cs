    private void InsertIntoTableXYZ(int valueID, string valueDescr, DateTime valueDate)
    {
        MyDataBase.MyCommand.CommandText = 
                  "INSERT INTO testTable (id,description,createDate) " +
                  "VALUES (" + valueID + ",'" + valueDescr + "','" + valueDate "')";
                       // no '' because it is int
        MyDataBase.MyConnection.Open();
        MyDataBase.MyCommand.ExecuteNonQuery();
        MyDataBase.MyConnection.Close();
    }
