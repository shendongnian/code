    public bool TryLogin(out string errMess)
    {
      *some other code is here*
      errMess = null;
      bool correct = false;
      try
      {
        if (_myConn.State == ConnectionState.Closed)
        {
            _myConn.Open();
            myCommand.ExecuteNonQuery();
        }
        if (Convert.ToInt32(myCommand.Parameters["@SQLVAR"].Value) < 1)
        {
            errMess = "Invalid Login" // I want to be the text of lblMessage.Text
        }
        else
        {
            correct = true;                 
        }
        _myConn.Close();
      }
      catch (Exception ex)
      {
        errMess = "Error connecting to the database" // I want to be the text of lblMessage.Text
      }
      return correct;
    }
