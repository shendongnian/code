    public partial class CommodityEdit : Form
    {
       SqlConnection MyConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
    
        public CommodityEdit()
        {
            InitializeComponent();
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               MyConnection.Open();
            }
            catch (Exception)
            {
                
                throw;
            }
