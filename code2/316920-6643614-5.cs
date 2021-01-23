    public int Result { get; private set; }
    private void Form1_Load(object sender, System.EventArgs e)
    { 
        Result = DoExportData(...);
    }
    
    private int DoExportData(DataRow dr, string cmdText)
    {
        try 
        {
            ...
            return 0;
        } 
        catch
        { 
            return -1; 
        }
    }
