protected void OnPreRender(object sender, EventArgs ex)
{
    base.OnPreRender(ex);
    DatePickers.Value = String.Join(",", GetDateParameters());
}
private IEnumerable<string> GetDateParameters()
{
    foreach (ReportParameterInfo info in ReportViewer2.ServerReport.GetParameters())
    {
        if (info.DataType == ParameterDataType.DateTime)
        {
            yield return string.Format("[{0}]", info.Prompt);
        }
    }
}
