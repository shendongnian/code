    public OleDbConnection Con;  
    public Form1() 
    { 
        InitializeComponent(); 
        string connetionString = null; 
        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:/Users/Mujahid/Documents/Visual Studio 2008/Projects/ts/ts/ts.accdb"; 
         
        Con = new OleDbConnection(connetionString); 
 
        try 
        { 
            Con.Open(); 
            MessageBox.Show("Connection Open ! "); 
            Con.Close(); 
 
        } 
        catch (Exception) 
        { 
            MessageBox.Show("Can not open connection ! "); 
        } 
 
    } 
