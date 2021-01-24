    .... previous stuff....
    if (ucRegister1.AllFieldsValidated() == true)
    {
        string[] details = ucRegister1.ReturnRegisterDetails();
        using(SqlConnection cnn = Helper.ConnectionToDB())
        {
            cnn.Open();
            SqlCommand cmdCU = new SqlCommand("......", cnn);
            .... replace all calls to Helper.ConnectionDB with the cnn variable ....
            .....
        }  // <== This close the connection 
    }
