        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["id"], out int id))
            {
                using (var db = new SampleDatabaseEntities())
                {
                    var report = new ProductReport();
                    var data = db.Prodcts.Where(x => x.Id == id).ToList();
                    report.SetDataSource(data);
                    CrystalReportViewer1.ReportSource = report;
                    CrystalReportViewer1.RefreshReport();
                }
            }
        }
