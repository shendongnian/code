public void isichartdomestic(System.Data.DataTable initialDataSource)
        {
            chart3.Titles.Add("Your title");
            chart3.Legends.Add("Your Legend");
             for (int i = 1; i < initialDataSource.Columns.Count; i++)
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series();
                foreach (DataRow dr in initialDataSource.Rows)
                {
                    double y = (double)dr[i];
                    series.Points.AddXY(dr["DiscPort"].ToString(), y);
                    TotalDomestic += y;
                }
                chart3.Series.Add(series);
                string NamaSeries = series.ToString();
                NamaSeries = NamaSeries.Replace("Series-","");
                chart3.Series[NamaSeries].IsValueShownAsLabel = true;
                chart3.Series[NamaSeries].IsVisibleInLegend = true;
                if (NamaSeries == "Series1")
                {
                    chart3.Series[NamaSeries].LegendText = "Bag";
                }
                else if (NamaSeries == "Series2")
                {
                    chart3.Series[NamaSeries].LegendText = "Bulk";
                }
                else if (NamaSeries == "Series3")
                {
                    chart3.Series[NamaSeries].LegendText = "Clinker";
                }
                else if (NamaSeries == "Series4")
                {
                    chart3.Series[NamaSeries].LegendText = "Container";
                }
            }
            lb_TotalDomestic.Text = Convert.ToString("Total Domestic: " + TotalDomestic);
            TotalDomesticExport += TotalDomestic;
            
        }
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/ROYVn.png
