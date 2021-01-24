    static string serverName;
    MySqlCommand command;
    public static string connString;
    // this is the method
    public void fill_grid(string query)
    {
    connString = @"server=" + serverName + "; Database=database; username=username; password=password";
    try
    {
    ....
    ....
