    public partial class PlugIn1 : StandardPlugIn
    {
        private void codeMetricProvider1_GetMetricValue(object sender, GetMetricValueEventArgs e)
        {
            e.Value = e.LanguageElement.GetCyclomaticComplexity();
        }
    }
