     protected void rblContentTypesGetAll_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)
          {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Global.conString))
            {
                using (SqlCommand cmd = new SqlCommand("contentTypeGetAll", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            //Clear Items before reloading
            rblContentTypesGetAll.Items.Clear();
        
            //Populate Radio button list
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rblContentTypesGetAll.Items.Add(new ListItem(dt.Rows[i]["contentType"].ToString() + " - " + dt.Rows[i]["description"].ToString(),
                    dt.Rows[i]["ID"].ToString()));
            }
        
            //Set Default Selected Item by Value
            rblContentTypesGetAll.SelectedIndex = rblContentTypesGetAll.Items.IndexOf(rblContentTypesGetAll.Items.FindByValue(((siteParams)Session["myParams"]).DefaultContentType.ToLower()));
          }
      }
