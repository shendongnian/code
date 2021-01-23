        using System.Data;
        using System.Drawing;
        using System.Data.SqlClient;
        using System.Collections;
        using System;
        using System.Linq;
    
        using Spire.Xls;
        using System.Collections.Generic;
    
        namespace _4SeriersChart
         x, 2].Text = countryInfo[i].Capital;
                       destSheet.Range[rowIndex, 3].Text = countryInfo[i].Continent;
                       destSheet.Range[rowIndex, 4].NumberValue = countryInfo[i].Area;
                       destSheet.Range[rowIndex, 5].NumberValue = countryInfo[i].Population;
                       destSheet.Pictures.Add(rowIndex, 6, countryInfo[i].Flag);
                       rowIndex++;
                    }
                    
                                //set style
                    destSheet = SetStyle(destBook, destSheet);
        
                    //Add Column Chart
                    destSheet = AddColumnChart(destSheet);
        
                    //Add Stacked Line Chart(Country and population
                    destSheet = AddStackLineChart(destSheet);
        
                    //Add Stacked Column chart(Country and area)
                    destSheet = AddStackColumnChart(destSheet);
        
                    destSheet.AllocatedRange.AutoFitColumns();
                    destBook.SaveToFile(@"..\..\CountryInfo.xls", ExcelVersion.Version97to2003);
                    System.Diagnostics.Process.Start(@"..\..\CountryInfo.xls");
                }
        
                private static Worksheet SetStyle(Workbook workbook, Worksheet sheet)
                {
                    //Sets body style
                    CellStyle oddStyle = workbook.Styles.Add("oddStyle");
                    oddStyle.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
                    oddStyle.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
                    oddStyle.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
                    oddStyle.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
                    oddStyle.KnownColor = ExcelColors.SkyBlue;
        
                    CellStyle evenStyle = workbook.Styles.Add("evenStyle");
                    evenStyle.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
                    evenStyle.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
                    evenStyle.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
                    evenStyle.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
                    evenStyle.KnownColor = ExcelColors.LightBlue;
        
                    foreach (CellRange range in sheet.AllocatedRange.Rows)
                    {
                        if (range.Row % 2 == 0)
                            range.CellStyleName = evenStyle.Name;
                        else
                            range.CellStyleName = oddStyle.Name;
                    }
        
                    //Sets header style
                    CellStyle styleHeader = sheet.Rows[0].Style;
                    styleHeader.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
                    styleHeader.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
                    styleHeader.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
                    styleHeader.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
                    styleHeader.VerticalAlignment = VerticalAlignType.Center;
                    styleHeader.KnownColor = ExcelColors.Color24;
                    styleHeader.Font.KnownColor = ExcelColors.White;
                    styleHeader.Font.IsBold = true;
        
                    return sheet;
                }
        
        
                //Add columnchart
        
                private static Worksheet AddColumnChart(Worksheet sheet)
                {
                    Chart chart = sheet.Charts.Add();
        
                    //Set region of chart data
                    chart.DataRange = sheet.Range["D1:E19"];
                    chart.SeriesDataFromRange = false;
        
                    //Set position of chart
                    chart.LeftColumn = 8;
                    chart.TopRow = 1;
                    chart.RightColumn = 17;
                    chart.BottomRow = 29;
        
                    chart.ChartType = ExcelChartType.ColumnClustered;
        
                    //Chart title
                    chart.ChartTitle = "Country Information";
                    chart.ChartTitleArea.Font.Color = Color.Red;
                    chart.ChartTitleArea.IsBold = true;
                    chart.ChartTitleArea.Size = 12;
        
                    chart.PrimaryCategoryAxis.Title = "Country";
                    chart.PrimaryCategoryAxis.TitleArea.Font.Color = Color.Red;
                    chart.PrimaryCategoryAxis.Font.IsBold = true;
                    chart.PrimaryCategoryAxis.TitleArea.IsBold = true;
        
        
                    //chart.PrimaryValueAxis.Title = "Sales(in Dollars)";
                    chart.PrimaryValueAxis.HasMajorGridLines = false;
                    chart.PrimaryValueAxis.MinValue = 0;
                    chart.PrimaryValueAxis.NumberFormatIndex = 50000000;
                    chart.PrimaryValueAxis.TitleArea.IsBold = true;
                    chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90;
        
                    //set the series lable 
                    chart.Series[0].CategoryLabels = sheet.Range["A2:A19"];
                    //chart.Series[0].CategoryLabels.
        
                    foreach (Spire.Xls.Charts.ChartSerie cs in chart.Series)
                    {
                        cs.Format.Options.IsVaryColor = true;
                        cs.DataPoints.DefaultDataPoint.DataLabels.HasValue = false;
                    }
        
                    chart.Legend.Position = LegendPositionType.Top;
                    return sheet;
                }
        
        
                //Add Stack Line chart
                private static Worksheet AddStackLineChart(Worksheet sheet)
                {
                    Chart chart = sheet.Charts.Add();
        
                    chart.DataRange = sheet.Range["E1:E19"];
                    chart.SeriesDataFromRange = false;
        
                    //Set position of chart
                    chart.LeftColumn = 1;
                    chart.TopRow = 31;
                    chart.RightColumn = 8;
                    chart.BottomRow = 49;
                    chart.ChartType = ExcelChartType.LineMarkersStacked;
        
                    //Chart Title
                    chart.ChartTitle = "Country Population Information";
                    //chart.ChartTitleArea.IsBold = true;
                    chart.ChartTitleArea.Size = 12;
        
                    chart.PrimaryCategoryAxis.Title = "Country";
                    //chart.PrimaryCategoryAxis.Font.IsBold = true;
                    chart.PrimaryCategoryAxis.TitleArea.IsBold = true;
        
                    chart.PrimaryValueAxis.HasMajorGridLines = false;
                    chart.PrimaryValueAxis.MinValue = 0;
                    chart.PrimaryValueAxis.NumberFormatIndex = 50000000;
                    chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90;
        
                    //set the series lable 
                    chart.Series[0].CategoryLabels = sheet.Range["A2:A19"];
        
                    chart.Legend.Position = LegendPositionType.Top;
                    return sheet;
                }
        
                //Add Stack Column chart
                private static Worksheet AddStackColumnChart(Worksheet sheet)
                {
        
                    Chart chart = sheet.Charts.Add();
                    chart.DataRange = sheet.Range["D1:D19"];
                    chart.SeriesDataFromRange = false;
        
                    chart.ChartType = ExcelChartType.ColumnStacked;
        
        
                    //Set position of chart
                    chart.LeftColumn = 9;
                    chart.TopRow = 31;
                    chart.RightColumn = 19;
                    chart.BottomRow = 49;
        
                    //Chart Title
                    chart.ChartTitle = "Country Area Information";
                    chart.ChartTitleArea.Size = 12;
        
                    chart.PrimaryCategoryAxis.Title = "Country";
                    chart.PrimaryCategoryAxis.TitleArea.IsBold = true;
        
                    chart.PrimaryValueAxis.HasMajorGridLines = false;
                    chart.PrimaryValueAxis.MinValue = 0;
                    chart.PrimaryValueAxis.NumberFormatIndex = 2000000;
                    chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90;
        
                    //set the series lable 
                    chart.Series[0].CategoryLabels = sheet.Range["A2:A19"];
        
                    chart.Legend.Position = LegendPositionType.Top;
                    return sheet;
                }
        
            }
        }
    
    
