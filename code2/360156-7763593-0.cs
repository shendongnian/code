    catch (OracleException e)
    {
        Cursor.Current = Cursors.Default;
        _instance = null;
    
        if (e.ErrorCode == -2147483648) // {"ORA-01017: invalid username/password; logon denied"}
        {
            MessageBox.Show("Nepravilno ime uporabnika ali geslo");
        }
        else
        {
            MessageBox.Show("Ne morem se povezati na podatkovno bazo. Preveri povezavo!");      
        }
    
        // this exits the program - you can also take other appropriate action here
        Environment.FailFast("Exiting because of blah blah blah");
    }
