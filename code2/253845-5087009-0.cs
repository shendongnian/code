        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Pretending to call your stored proc..
                DataTable dt = new DataTable();
                dt.Columns.Add("contentType");
                dt.Columns.Add("description");
                dt.Columns.Add("ID");
                dt.AcceptChanges();
                for (int i = 0; i < 6; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["contentType"] = "cnt" + i.ToString();
                    dr["description"] = "desc" + i.ToString();
                    dr["ID"] = i.ToString();
                    dt.Rows.Add(dr);
                }
                //Populate Radio button list
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rblContentTypesGetAll.Items.Add(new ListItem(dt.Rows[i]["contentType"].ToString() + " - " + dt.Rows[i]["description"].ToString(),
                        dt.Rows[i]["ID"].ToString()));
                }
                //Set Default Selected Item by Value
                rblContentTypesGetAll.SelectedIndex = 0; //this could be -1 also
            }
            lblMessage.Text = "rblContentTypesGetAll.SelectedValue :" + rblContentTypesGetAll.SelectedValue;
        }
