    protected void Page_Load(object sender, EventArgs e)
            {
            if(!Page.IsPostBack)
                {
                Populate();                
                }
        }
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            myConnection.Open();
            try
            {
                SqlDataReader reader = null;
                string serverIP = drpChoose.SelectedItem.Value.ToString();
                SqlCommand cmd = new SqlCommand("SELECT * from ScheduledTasks WHERE ServerIP = " + serverIP, myConnection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            myConnection.Close();
        }
        public void Populate()
        {
            SqlConnection myConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            myConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT ServerIP FROM Servers", myConnection1);
            SqlDataReader dropReader;
            dropReader = cmd1.ExecuteReader();
            drpChoose.DataSource = dropReader;
            drpChoose.DataTextField = "ServerIP";
            drpChoose.DataValueField = "ServerIP";
            drpChoose.DataBind();
        }
    }
