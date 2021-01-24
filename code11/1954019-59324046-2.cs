    public User(string line)
    {
        var data = line.Split('|');
        if (data.Length > 2 || data.Length == 0)
        {
            //Bad Data Throw Error, Roll Kick and Scream. 
        }
        Login = data[0];
        Password = data[1];
    }
