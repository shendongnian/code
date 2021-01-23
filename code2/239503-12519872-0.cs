    public ActionResult Chart()
    {
        var chart = buildChart();
        StringBuilder result = new StringBuilder();
        result.Append(getChartImage(chart));
        result.Append(chart.GetHtmlImageMap("ImageMap"));
        return Content(result.ToString());
    }
