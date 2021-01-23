    public partial class ScanFolder : Form
    {
        public ScanFolder()
        {
             InitializeComponent(); // added by VS
        }
        public ScanFolder(MainForm parent, bool[] autoModes, GlobalMethods gm)
           : this() // <-- important
        {
             // don't forget to call the parameterless ctor in each
             // of your ctor overloads
        }
    }
