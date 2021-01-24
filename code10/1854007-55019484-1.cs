    clsDBConnector dbConnector1 = new clsDBConnector();​
    OleDbDataReader dr1;​
    string sqlStr1;​
    dbConnector1.Connect();​
    for (int i = 40; i < 1425; i++)​ //40-1425 is customerID's
    {
       // process data
    }
    dbConnector1.Close();
