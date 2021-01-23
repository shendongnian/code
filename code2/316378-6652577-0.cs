    namespace DSNUtility{
    
    public partial class Form1 : Form{
    [DllImport("odbccp.dll")]
    private static extern bool SQLConfigDataSource(IntPrt parent, int request, string driver, string attribute;
    public form(){
    InitializeComponent();
    }
    //Method to handle the creation(Will be called on a Button Click)
    public bool AddUserDSN(){
    return SQLConfigDataSource((IntPrt)0, 1, "SQL Server",
    "DSN=Testing123\0Description=Testing123\0Network=blahblah\0Trusted_Connection=No\0Server=blahblahblah\0Database=XXXXXX\0");
    }
    private void Form1_Load(object sender, EventArgs e){
    //Call the Add User Method   
    AddUserDSN();
    }
    }
    }
  
