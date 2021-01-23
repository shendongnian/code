    protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }
        protected void GetDateEntries_Click(object sender, EventArgs e)
        {
            dgArchive.Visible = true;
            using (Entities ent = new Entities(ConfigurationManager.ConnectionStrings["QCConnString"].ToString()))
            {
                DateTime start = Convert.ToDateTime(Start.Text);
                DateTime end = Convert.ToDateTime(End.Text).AddDays(1);
                AllDataSources ds = new AllDataSources();
                CamsizerData cd = new CamsizerData();
                IEnumerable<CamsizerData> led = cd.GetBySelectedDates(ent, start, end);
                int counter = led.Count();
                dgArchive.VirtualItemCount = counter;
                dgArchive.DataSource = ds.populateArchive(ent, start, end);
                dgArchive.DataBind();
            }
        }
        protected void dgArchive_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            if (source != null)
            {                
                dgArchive.CurrentPageIndex = e.NewPageIndex;
                Entities ent = new Entities(ConfigurationManager.ConnectionStrings["QCConnString"].ToString());
                DateTime start = Convert.ToDateTime(Start.Text);
                DateTime end = Convert.ToDateTime(End.Text).AddDays(1);
                AllDataSources ds = new AllDataSources();
                IEnumerable<object> recs = ds.populateArchive(ent, start, end);
                dgArchive.DataSource = recs.Skip(10 * e.NewPageIndex);
                dgArchive.DataBind();
            }
        }
