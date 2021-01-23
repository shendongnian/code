    @(Html
    .TelerikReporting()
    .ReportViewer()
    .Id("reportViewer1")
    .ServiceUrl(Url.Content("/Controllers/Reports/"))
    //Setting the ReportSource Parameters overrides the default specified in the report.
    .ReportSource(new TypeReportSource() { TypeName = @ViewBag.TypeName, Parameters = { new Parameter("startDate", Request.QueryString["startDate"]) } }) 
    //To make the query string parameter optional, try:
    //.ReportSource(new TypeReportSource() { TypeName = @ViewBag.TypeName, Parameters = { Request.QueryString["startDate"] != null ? new Parameter("startDate", Request.QueryString["startDate"]) : new Parameter() } })
    .ViewMode(ViewMode.Interactive)
    .ScaleMode(ScaleMode.Specific)
    .Scale(1.0)
    .PersistSession(false)
    .PrintMode(PrintMode.AutoSelect)
    )
