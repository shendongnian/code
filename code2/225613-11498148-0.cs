           protected void Page_Load(object sender, EventArgs e)
         {
            this.data1();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/xyz.xml"));
            lblMsg.Text = ds.Tables[0].Rows[0]["data"].ToString();
        }
        private void data1()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/xyz.xml"));
            int data = Int32.Parse(ds.Tables[0].Rows[0]["data"].ToString());
            hits += 1;
            ds.Tables[0].Rows[0]["data"] = data.ToString();
            ds.WriteXml(Server.MapPath("~/xyz.xml"));
        }
