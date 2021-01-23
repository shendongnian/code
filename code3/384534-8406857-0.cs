            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            chart.Series.Add(new Series("Data"));
            chart.Legends.Add(new Legend("Stores"));
            chart.Series["Data"].ChartType = SeriesChartType.Pie;
            chart.Series["Data"]["PieLabelStyle"] = "Outside";
            chart.Series["Data"]["PieLineColor"] = "Black";
            for (int x = 0; x < viewModel.SalesInStorePerPaymentCollected.XValues.Length; x++)
            {
               int ptIdx = chart.Series["Data"].Points.AddXY(
                    viewModel.SalesInStorePerPaymentCollected.XValues[x],
                    viewModel.SalesInStorePerPaymentCollected.YValues[x]);
               DataPoint pt = chart.Series["Data"].Points[ptIdx];
               pt.LegendText = "#VALX: #VALY";
               pt.LegendUrl = "/Contact/Details/Hey";
            }
            chart.Series["Data"].Label = "#PERCENT{P0}";
            chart.Series["Data"].Font = new Font("Segoe UI", 8.0f, FontStyle.Bold);
            chart.Series["Data"].ChartType = SeriesChartType.Pie;
            chart.Series["Data"]["PieLabelStyle"] = "Outside";
            chart.Series["Data"].Legend = "Stores";
            chart.Legends["Stores"].Docking = Docking.Bottom;
            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            return new FileStreamResult(returnStream, "image/png");
