     public partial class MainForm : Form
     {
            private Dictionary<String , PropertyInfo[]> types = new Dictionary<String , PropertyInfo[]>();
            public MainForm()
            {
                //OpenAccountStruct is in the scope
                types.Add("OpenAccount", new OpenAccountStruct().GetType().GetProperties());
            }
    } 
