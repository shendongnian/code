    public partial class Form1 : Form
    {
        readonly SqlConnection con; // readonly as we want to keep that one connection around.
        int Id = 0;
        public Form1()
        {
            InitializeComponent();
            string conStr = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            con =  = new SqlConnection(conStr);
        }
