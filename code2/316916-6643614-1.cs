    public int Result { get; private set; }
    private void Form1_Load(object sender, System.EventArgs e)
    { 
        the code..in turn also calling some sub functions such as DoExportData...and I want to be able to return the value to main from any function...
    }
    
    private int DoExportData(DataRow dr, string cmdText)
    {
        try 
        {
            ...
            Result = 0;
        } 
        catch
        { 
            Result = -1; 
        }
    }
