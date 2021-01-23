    private void FillChart()
    {
        // fill the data table with values
        var dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("City", typeof(string));
        dt.Columns.Add("State", typeof(string));
        dt.Columns.Add("Population", typeof(int));
    
        dt.Rows.Add(0, "City1", "State1", 100);
        dt.Rows.Add(1, "City2", "State1", 30);
        dt.Rows.Add(2, "City3", "State1", 40);
        dt.Rows.Add(3, "City1", "State2", 80);
        dt.Rows.Add(4, "City2", "State2", 70);
    
        // bind the data table to chart
        this.chart1.Series.Clear();
    
        var series = this.chart1.Series.Add("Series 1");
        series.XValueMember = "Id";
        series.YValueMembers = "Population";
    
        series.ChartType = SeriesChartType.Column;
        this.chart1.DataSource = dt;
        this.chart1.DataBind();
    
        // custom labels 
        foreach (var g in dt.AsEnumerable().GroupBy(x => x.Field<string>("State")))
        {
            string state = g.Key;
            var cities = g.Select(r => new { Id = r.Field<int>("Id"), City = r.Field<string>("City") });
            // find min-max
            int min = cities.Min(y => y.Id);
            int max = cities.Max(y => y.Id);
            // city labels
            foreach (var city in cities)
            {
                var label = new CustomLabel(city.Id - 1, city.Id + 1, city.City, 0, LabelMarkStyle.None);
                this.chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
            }
            // city states
            var statelabel = new CustomLabel(min, max, state, 1, LabelMarkStyle.LineSideMark);
            this.chart1.ChartAreas[0].AxisX.CustomLabels.Add(statelabel);
        }
    }
