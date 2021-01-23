        public ReportViewer(IEnumerable<UnprocessedLabel> labels)
        {
            InitializeComponent();
            var reportViewer = new Microsoft.Reporting.WinForms.ReportViewer { ProcessingMode = ProcessingMode.Local };
            reportViewer.LocalReport.ReportPath = System.IO.Path.GetDirectoryName(Application.ResourceAssembly.Location) + "\\UnprocessedPalletLabel.rdlc";
            var ds = new ReportDataSource("labels", labels);
            reportViewer.LocalReport.DataSources.Add(ds);
            reportViewer.RefreshReport();
        }
