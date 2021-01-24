    protected void SummarySelected(UIChangeEventArgs e)
    {
        var currSummary = e.Value.ToString();
        if (currSummary.Equals("All"))
        {
            forecasts = origForecasts;
        }
        else
        {
            forecasts = origForecasts.Where(f => f.Summary.Equals(currSummary)).ToList();
        }
    }
