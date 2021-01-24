private void AddPieChart(ExcelWorksheet worksheet, int firstDataRow, int firstDataColumn, int lastDataRow, int nextColumn, int firstColumn)
        {
            ExcelPieChart pieChart = worksheet.Drawings.AddChart(worksheet.Name.ToString() + " Pie Chart", eChartType.Pie3D) as ExcelPieChart;
            var serie = pieChart.Series.Add(ExcelCellBase.GetAddress(firstDataRow + 3, firstDataColumn, lastDataRow + 3, firstDataColumn),
                                            ExcelCellBase.GetAddress(firstDataRow + 3, firstColumn, lastDataRow + 3, firstColumn));
            pieChart.Legend.Remove();
            pieChart.SetSize(500, 350);
            pieChart.SetPosition(lastDataRow + 5, 0, nextColumn - 1, 0);
            pieChart.Border.Fill.Color = Color.White;
            pieChart.Series.Chart.RoundedCorners = false;
            var pieSerie = (ExcelPieChartSerie)serie;
            pieSerie.DataLabel.ShowCategory = true;
            pieSerie.DataLabel.ShowLeaderLines = true;
            pieSerie.DataLabel.Font.Bold = true;
            pieSerie.DataLabel.Font.Size = 12;
            pieSerie.DataLabel.Position = eLabelPosition.OutEnd;
        }
