        private FlowDocument HydroPowerReportI(string PlantPath, string PlantName, bool filled)
        {
            //Ignore these first 20 lines, they are there to populate my data
            List<HydroMarket.LocalData.BinaryIO.HydroFileIO.Report1> data = new List<HydroMarket.LocalData.BinaryIO.HydroFileIO.Report1>();
            int nTime = 0;
            List<int> iReportingPoints = new List<int>();
            SimulationsTreeViewModel S = (this.DataContext as SimulationsTreeViewModel);
            List<DateTime> dates = new List<DateTime>();
            if (filled)
            {
                if (HydroFileIO.ObtainReportI(data, out nTime, PlantPath))
                {
                    MarketParameters m = MarketParameters.ReadScenarioParameters(new FileInfo(System.IO.Path.Combine(PlantPath, "MarketParam.bin")));
                    iReportingPoints.Add(0); 
                    iReportingPoints.Add(1); 
                    iReportingPoints.Add(2); 
                    iReportingPoints.Add(3);
                    iReportingPoints.Add(4);
                    dates.Add(m.ValueDate);
                    foreach (DateTime x in m.ReportingDates)
                    {
                        DateTime dt = SetBetween(m.ValueDate, x, m.Maturity);
                        dates.Add(dt);
                    }
                    dates.Add(m.Maturity);
                }
                else
                {
                    filled = false;
                }
            }
            //START of FlowDocument 
            Brush HeaderColor = Brushes.RoyalBlue;
            FlowDocument flowDoc = new FlowDocument();
            //Original table holder with columns
            Table table2 = new Table();
            flowDoc.Blocks.Add(table2);
            table2.Columns.Add(new TableColumn());
            table2.Columns.Add(new TableColumn());
            table2.Columns.Add(new TableColumn());
            table2.Columns.Add(new TableColumn());
            table2.Columns.Add(new TableColumn());
            table2.Columns.Add(new TableColumn());
            table2.Columns[0].Width = new GridLength(280);
            // Create and add an empty TableRowGroup to hold the table's Rows.
            table2.RowGroups.Add(new TableRowGroup());
            // Add the first (title) row.
            table2.RowGroups[0].Rows.Add(new TableRow());
            // Alias the current working row for easy reference.
            TableRow currentRow2 = new TableRow();
            currentRow2 = table2.RowGroups[0].Rows[0];
            // Add cells with content to the second row.
            currentRow2.Cells.Add(new TableCell(new Paragraph(new Run("Valuation Report"))));
            currentRow2.Cells[0].ColumnSpan = 6; //1 less than center for offsetting it
            currentRow2.FontSize = 32;
            currentRow2.Foreground = HeaderColor;
            currentRow2.Cells[0].TextAlignment = TextAlignment.Left;
            table2.RowGroups[0].Rows.Add(new TableRow());
            currentRow2 = table2.RowGroups[0].Rows[1];
            if (filled)
                if (S.SimSetup.LastSimulation.HasValue)
                    currentRow2.Cells.Add(new TableCell(new Paragraph(new Run("Valuation: " + S.Name + "\nMarket: " + S.SimSetup.Market.Name + "\nPlant: " + PlantName + "\nLast simulated at: " + S.SimSetup.LastSimulation.Value.ToLongDateString() + " " + S.SimSetup.LastSimulation.Value.ToShortTimeString()))));
                else
                    currentRow2.Cells.Add(new TableCell(new Paragraph(new Run("Valuation: " + S.Name + "\nMarket: " + S.SimSetup.Market.Name + "\nPlant: " + PlantName))));
            else
            {
                //BUGFIX: 091113 
                //When no data is loaded, it is unclear that it has not loaded data
                currentRow2.Cells.Add(new TableCell(new Paragraph(new Run("No simulation data available for valuation " + S.Name))));
            }
            currentRow2.Cells[0].TextAlignment = TextAlignment.Left;
            currentRow2.Cells[0].ColumnSpan = 6; //all for the center
            currentRow2.Cells[0].Padding = new Thickness(10);
            //Table Headers
            // Create and add an empty TableRowGroup to hold the table//s Rows.
            table2.RowGroups.Add(new TableRowGroup());
            // Add the first (title) row.
            table2.RowGroups[1].Rows.Add(new TableRow());
            // Alias the current working row for easy reference.
            int iRow = 0;
            TableRow currentRow = new TableRow();
            currentRow = table2.RowGroups[1].Rows[iRow];
            // Add the header row with content,
            if (filled)
            {
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Value date"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Maturity"))));
                
                table2.RowGroups[1].Rows.Add(new TableRow());
                iRow = 1;
                currentRow = table2.RowGroups[1].Rows[iRow];
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(dates[0].ToShortDateString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(dates[1].ToShortDateString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(dates[2].ToShortDateString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(dates[3].ToShortDateString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(dates[4].ToShortDateString()))));
            }
            else
            {
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Value date"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Maturity"))));
                table2.RowGroups[1].Rows.Add(new TableRow());
                iRow = 1;
                currentRow = table2.RowGroups[1].Rows[iRow];
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(" "))));
            }
            for (int i = 0; i < 6; i++)
            {
                currentRow.Cells[i].Foreground = HeaderColor;
                currentRow.Cells[i].TextAlignment = TextAlignment.Right;
            }
            iRow++;
            table2.RowGroups[1].Rows.Add(new TableRow());
            currentRow = table2.RowGroups[1].Rows[iRow];
            currentRow.Cells.Add(new TableCell());
            currentRow.Cells[0].ColumnSpan = 6;
            currentRow.Cells[0].BorderThickness = new Thickness(0, 5, 0, 0);
            currentRow.Cells[0].BorderBrush = HeaderColor;
            for (int i = 3; i < 23; i++)
            {
                table2.RowGroups[1].Rows.Add(new TableRow());
                currentRow = table2.RowGroups[1].Rows[i];
            }
            table2.RowGroups[1].Rows[3].Cells.Add(new TableCell(new Paragraph(new Run("Expected value"))));
            table2.RowGroups[1].Rows[4].Cells.Add(new TableCell(new Paragraph(new Run("Expected price"))));
            table2.RowGroups[1].Rows[5].Cells.Add(new TableCell(new Paragraph(new Run("Expected income (cumulated)"))));
            table2.RowGroups[1].Rows[6].Cells.Add(new TableCell(new Paragraph(new Run("Expected income"))));
            table2.RowGroups[1].Rows[7].Cells.Add(new TableCell(new Paragraph(new Run("Expected income by generation"))));
            table2.RowGroups[1].Rows[8].Cells.Add(new TableCell(new Paragraph(new Run("Expected costs of pumping"))));
            table2.RowGroups[1].Rows[9].Cells.Add(new TableCell(new Paragraph(new Run("Expected penalties"))));
            table2.RowGroups[1].Rows[10].Cells.Add(new TableCell(new Paragraph(new Run("Expected costs of switching on/off"))));
            table2.RowGroups[1].Rows[11].Cells.Add(new TableCell(new Paragraph(new Run("Standard deviation of value"))));
            table2.RowGroups[1].Rows[12].Cells.Add(new TableCell(new Paragraph(new Run("Value at Risk (95%)"))));
            table2.RowGroups[1].Rows[13].Cells.Add(new TableCell(new Paragraph(new Run("Generated electricity (MWh)"))));
            table2.RowGroups[1].Rows[14].Cells.Add(new TableCell(new Paragraph(new Run("Consumed electricity (MWh)"))));
            table2.RowGroups[1].Rows[15].Cells.Add(new TableCell(new Paragraph(new Run("Days generated"))));
            table2.RowGroups[1].Rows[16].Cells.Add(new TableCell(new Paragraph(new Run("Days pumped"))));
            table2.RowGroups[1].Rows[17].Cells.Add(new TableCell(new Paragraph(new Run("Expected volume (m³)"))));
            table2.RowGroups[1].Rows[18].Cells.Add(new TableCell(new Paragraph(new Run("Expected volume used for generation (m³)"))));
            table2.RowGroups[1].Rows[19].Cells.Add(new TableCell(new Paragraph(new Run("Expected volume used for pumping (m³)"))));
            table2.RowGroups[1].Rows[20].Cells.Add(new TableCell(new Paragraph(new Run("Expected volume natural inflow (m³)"))));
            table2.RowGroups[1].Rows[21].Cells.Add(new TableCell(new Paragraph(new Run("Standard deviation of volume"))));
            table2.RowGroups[1].Rows[22].Cells.Add(new TableCell(new Paragraph(new Run("Volume at risk"))));
            if (filled)
            {
                //Writing 
                for (int j = 0; j < 5; j++)
                {
                    table2.RowGroups[1].Rows[3].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].Value.ToString("N0")))));
                    table2.RowGroups[1].Rows[4].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].Price.ToString("N0")))));
                    table2.RowGroups[1].Rows[5].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].IncomeCum.ToString("N0")))));
                    table2.RowGroups[1].Rows[6].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].Income.ToString("N0")))));
                    //table2.RowGroups[1].Rows[6].Cells.Add(new TableCell(new Paragraph(new Run(income[j].ToString("N0")))));
                    table2.RowGroups[1].Rows[7].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].IncomeGen.ToString("N0")))));
                    table2.RowGroups[1].Rows[8].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].CostsPmp.ToString("N0")))));
                    table2.RowGroups[1].Rows[9].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].Penalties.ToString("N0")))));
                    table2.RowGroups[1].Rows[10].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].CostSwitch.ToString("N0")))));
                    table2.RowGroups[1].Rows[11].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].StdValue.ToString("N0")))));
                    table2.RowGroups[1].Rows[12].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].VaRValue.ToString("N0")))));
                    table2.RowGroups[1].Rows[13].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].PowGen.ToString("N0")))));
                    table2.RowGroups[1].Rows[14].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].PowPump.ToString("N0")))));
                    table2.RowGroups[1].Rows[15].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].DaysGen.ToString("N0")))));
                    table2.RowGroups[1].Rows[16].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].DaysPmp.ToString("N0")))));
                    table2.RowGroups[1].Rows[17].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].Volume.ToString("N0")))));
                    table2.RowGroups[1].Rows[18].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].VolGen.ToString("N0")))));
                    table2.RowGroups[1].Rows[19].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].VolPmp.ToString("N0")))));
                    table2.RowGroups[1].Rows[20].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].VolNat.ToString("N0")))));
                    table2.RowGroups[1].Rows[21].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].StdVolume.ToString("N0")))));
                    table2.RowGroups[1].Rows[22].Cells.Add(new TableCell(new Paragraph(new Run(data[iReportingPoints[j]].VaRVolume.ToString("N0")))));
                }
            }
            else
            {
                double d = 0.00;
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 3; k < 23; k++)
                        table2.RowGroups[1].Rows[k].Cells.Add((new TableCell(new Paragraph(new Run(d.ToString("N0"))))));
                }
            }
            for (int r = 3; r < 23; r++)
                for (int j = 1; j < 6; j++)
                    table2.RowGroups[1].Rows[r].Cells[j].TextAlignment = TextAlignment.Right;
           
            for (int j = 0; j < 6; j++)
            {
                table2.RowGroups[1].Rows[10].Cells[j].BorderThickness = new Thickness(0, 1, 0, 0);
                table2.RowGroups[1].Rows[10].Cells[j].BorderBrush = Brushes.Black;
                table2.RowGroups[1].Rows[12].Cells[j].BorderThickness = new Thickness(0, 1, 0, 0);
                table2.RowGroups[1].Rows[12].Cells[j].BorderBrush = Brushes.Black;
                table2.RowGroups[1].Rows[14].Cells[j].BorderThickness = new Thickness(0, 1, 0, 0);
                table2.RowGroups[1].Rows[14].Cells[j].BorderBrush = Brushes.Black;
                table2.RowGroups[1].Rows[20].Cells[j].BorderThickness = new Thickness(0, 1, 0, 0);
                table2.RowGroups[1].Rows[20].Cells[j].BorderBrush = Brushes.Black;
                table2.RowGroups[1].Rows[22].Cells[j].BorderThickness = new Thickness(0, 1, 0, 0);
                table2.RowGroups[1].Rows[22].Cells[j].BorderBrush = Brushes.Black;
            }
            return flowDoc;
        }
