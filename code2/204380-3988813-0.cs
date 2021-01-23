    public void SetChartData(IDictionary<string, IDictionary<string, double>> prod, String title, String labelAxis)
            {   
               chart.Title = title;
               LinearAxis ca = new LinearAxis();
               ca.Orientation = AxisOrientation.Y;
               ca.Minimum = 0;
               chart.Axes.Add(ca);
               foreach (KeyValuePair<string, IDictionary<string, double>> kvp in prod)
               {
                   ColumnSeries cser = new ColumnSeries();
                   cser.Title = kvp.Key;
                 cser.DependentValueBinding = new Binding("Value");
                  cser.IndependentValueBinding = new Binding("Key");
                  cser.ItemsSource = kvp.Value;
                   chart.Series.Add(cser);
               }
            }
