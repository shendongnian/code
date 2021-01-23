    public ActionResult BasicLine()
        {
            Highcharts chart = new Highcharts("chart")
                .InitChart(new Chart
                           {
                               DefaultSeriesType = ChartTypes.Line,
                               MarginRight = 130,
                               MarginBottom = 25,
                               ClassName = "chart"
                           })
                .SetTitle(new Title
                          {
                              Text = "Monthly Average Temperature",
                              X = -20
                          })
                .SetSubtitle(new Subtitle
                             {
                                 Text = "Source: WorldClimate.com",
                                 X = -20
                             })
                .SetXAxis(new XAxis { Categories = ChartsData.Categories })
                .SetYAxis(new YAxis
                          {
                              Title = new XAxisTitle { Text = "Temperature (°C)" },
                              PlotLines = new[]
                                          {
                                              new XAxisPlotLines
                                              {
                                                  Value = 0,
                                                  Width = 1,
                                                  Color = ColorTranslator.FromHtml("#808080")
                                              }
                                          }
                          })
                .SetTooltip(new Tooltip
                            {
                                Formatter = @"function() {
                                        return '<b>'+ this.series.name +'</b><br/>'+
                                    this.x +': '+ this.y +'°C';
                                }"
                            })
                .SetLegend(new Legend
                           {
                               Layout = Layouts.Vertical,
                               Align = HorizontalAligns.Right,
                               VerticalAlign = VerticalAligns.Top,
                               X = -10,
                               Y = 100,
                               BorderWidth = 0
                           })
                .SetSeries(new[]
                           {
                               new Series { Name = "Tokyo", Data = new Data(new object[] { 7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6 }) },
                               new Series { Name = "New York", Data = new Data(new object[] { -0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5 }) },
                               new Series { Name = "Berlin", Data = new Data(new object[] { -0.9, 0.6, 3.5, 8.4, 13.5, 17.0, 18.6, 17.9, 14.3, 9.0, 3.9, 1.0 }) },
                               new Series { Name = "London", Data = new Data(new object[] { 3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8 }) }
                           }
                );
            return View(chart);
        }
