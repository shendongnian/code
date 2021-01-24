    public void assignList(ref List<list_chart> lc, DataTable dtMetric, string metricname)
    {
        lc = (from dr1 in dtMetric.AsEnumerable()
              where dr1.Field<string>("METRIC_NAME") == metricname
              orderby dr1["SAMPLE_TIME"] ascending
              select new list_chart
              {
                  SAMPLE_TIME = dr1.Field<DateTime>("SAMPLE_TIME"),
                  Value = dr1.Field<decimal>("value")
              }).ToList();
    }
    //lc has 100 records but listchart1 still shows 0 after i call method.
    assignList(ref listchart1, dtMetric1, ucMetrics.CheckedItems[0].DisplayText);
