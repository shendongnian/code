        viewer.Reset();
        ReportDataSource dataSource = new ReportDataSource();
        // I use a service/repository; you could also use Linq2Sql or EntityFramework 
        IList<Redemption> redemptions = _service.GetRedemptions(merchantId);
        BindingSource bindingSource = new BindingSource(redemptions, string.Empty);
        dataSource.Name = "Redemptions";
        dataSource.Value = bindingSource;
        viewer.LocalReport.DataSources.Add(getDataSource(sourceInfo));
        String reportName = "AD.Conso.MyReport.rdlc";
        viewer.LocalReport.ReportEmbeddedResource = reportName;
        IList<ReportParameter> parameters = new List<ReportParameter>();
        parameters.Add(new ReportParameter("myParameterName", "myParameterValue"));
        viewer.LocalReport.SetParameters(parameters);
        viewer.RefreshReport();
