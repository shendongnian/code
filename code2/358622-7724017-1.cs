    public string DoPing(Object IP)
    {
        if (IP.GetType() == typeof(string))
        {
            return DoPingString((String)IP);
        }
        if (IP.GetType() == typeof(IPAddress))
        {
            return DoPingIP((IPAddress)IP);
        }
        throw new Exception("Programmer Error");
    }
