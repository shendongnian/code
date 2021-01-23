    private static object _lock = new object();
    public void LogIn(string username, string password)
    {
        lock(_lock)
        {
            if (NumLoggedInUsers() >= MaxNumUsers())
            {
                return "Sry dudez, too many userz";
            }
        }
    }
