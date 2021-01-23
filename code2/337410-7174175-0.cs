    foreach (string line in File.ReadLines(filename))
    {
        string usernameFromText = (line.Split(','))[0];
        string passwordFromText = (line.Split(','))[2];
        if (username == usernameFromText && password == passwordFromText)
        {
             return "Successfully Logged in!";
        }
    }
    return "Your Username / Password is Invalid!";
