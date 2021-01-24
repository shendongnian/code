         protected void Page_Load(object sender, EventArgs e)
                {
                    if (!IsPostBack)
                    {
                        BindGrid();
                    }
                }
                 
            private void BindGrid()
            {
                string conStr = @"Your connection string here";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Table_Name"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
        
