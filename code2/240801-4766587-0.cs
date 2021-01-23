            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // initially btnLogin has a DialogResult property set to None
            Authenticate();
        }
        private void Authenticate()
        {
            SqlCeConnection conn = new SqlCeConnection(@"Data source=d:/BIMS.sdf");
            conn.Open();
            SqlCeCommand cmd = new SqlCeCommand(Properties.Resources.CheckIfUserExists, conn);
            cmd.Parameters.Add("username", txtUsername.Text.Trim());
            cmd.Parameters.Add("password", txtPassword.Text.Trim());
            SqlCeDataReader dr = cmd.ExecuteReader();
            bool hasRow = dr.Read();
            if (hasRow)
            {
                Main formmain = new Main();
                formmain.Show();
                this.Dispose(); // U can also use this.Close();
            }
        }
    }
}
