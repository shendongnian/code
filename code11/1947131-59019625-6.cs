    public partial class Form1 : Form
    {
        // assume we create and assign an instance once
        // so mark the var readonly
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
        int Id = 0;
        public Form1()
        {
            InitializeComponent();
        }
