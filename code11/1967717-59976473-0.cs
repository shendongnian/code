    public partial class FrmItems : MaterialSkin.Controls.MaterialForm
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Users\Admin\source\repos\Elektrokalkulace\Stock.mdf;Integrated Security=True;Connect Timeout=30");
        
        int CatId;
        
        public FrmItems()
        {
            InitializeComponent();
            refreshCat();
         
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
           
        }
        private void FrmItems_Load(object sender, EventArgs e)
        {
        }
        private void refreshCat()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            CbxCat.DisplayMember = "NameCat";
            CbxCat.ValueMember = "CatId";
            CbxCat.DataSource = dt;
        }
        
        private void CbxCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxCat.SelectedValue.ToString() != null)
            {
                CatId = Convert.ToInt32(CbxCat.SelectedValue.ToString());
                refreshSubcat(CatId);
            }
        }
        private void refreshSubcat(int CatId)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Subcategories WHERE CatId=@CatId", conn);
            cmd.Parameters.AddWithValue("CatId", CatId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            CbxSubcat.DisplayMember = "NameSubcat";
            CbxSubcat.ValueMember = "SubcatId";
            CbxSubcat.DataSource = dt;
        }   
        private void CbxSubcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Items WHERE SubCatId='" + CbxSubcat.SelectedValue + "'", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            dataGridViewItem.DataSource = dt;
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmMainMenu menu = new FrmMainMenu();
            menu.Show();
            this.Hide();
        }
    }
    enter code here
