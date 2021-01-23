    private static MySqlConnection masterOpenCON;
    
    static void Main(string[] args)
    {
        OpenCon();
    }
    
    public static MySqlConnection OpenCon()
    {
        masterOpenCON = new MySqlConnection(SQLStringClass.masterConString);
        masterOpenCON.Open();
        return masterOpenCON;
    }
