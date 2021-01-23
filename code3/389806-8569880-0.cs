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
    
    
    The class i defied to storage the data:
       
    
         using System.Data;
        using System.Drawing;
        using System.Data.SqlClient;
        using System.Collections;
        using System;
        using System.Linq;
        
        using Spire.Xls;
        using System.Collections.Generic;
        
        namespace _4SeriersChart
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Workbook sourceBook = new Workbook();
                    sourceBook.LoadFromFile(@"..\..\Exercise.xls", ExcelVersion.Version97to2003);
                    Worksheet sourceSheet = sourceBook.Worksheets[0];
        
                    DataTable SourceTable = sourceSheet.ExportDataTable();
        
                    for (int i = 0; i < sourceSheet.Pictures.Count; i++)
                    {
                        ExcelPicture pic = sourceSheet.Pictures[i];
                    }
        
                    List<Country> countryInfo = new List<Country>();
        
                    for (int i = 1, k = 0; i < sourceSheet.Rows.Length && k < sourceSheet.Pictures.Count; i++, k++)
                    {
                        int j = 0;
                        countryInfo.Add(
                             new Country
                             {
                                 Name = sourceSheet.Rows[i].Columns[j].Text,
                                 Capital = sourceSheet.Rows[i].Columns[j + 1].Text,
                                 Continent = sourceSheet.Rows[i].Columns[j + 2].Text,
                                 Area = Convert.ToSingle(sourceSheet.Rows[i].Columns[j + 3].NumberValue),
                                 Population = Convert.ToSingle(sourceSheet.Rows[i].Columns[j + 4].NumberValue),
                                 Flag = sourceSheet.Pictures[k].Picture
                             }
                         );
                    }
        
                    //Sort the List
                    countryInfo.Sort(Country.compare);
        
                    Workbook destBook = new Workbook();
                    //Initailize worksheet
                    destBook.CreateEmptySheets(1);
                    Worksheet destSheet = destBook.Worksheets[0];
                    destSheet.Name = "Country Information";
        
                    //inset the first row
        
                    for (int i = 1; i <= sourceSheet.Columns.Length;i++ )
                    {
                        destSheet.Range[1, i].Text = sourceSheet.Range[1, i].Text;
                    }
        
                    //insert data
                    int rowIndex = 2;
                    for (int i = 0; i < countryInfo.Count;i++ )
                    {
                        int j=0;
                       destSheet.Range[rowIndex, 1].Text = countryInfo[i].Name;
                       destSheet.Range[rowIndex, 2].Text = countryInfo[i].Capital;
                       destSheet.Range[rowIndex, 3].Text = countryInfo[i].Continent;
                       destSheet.Range[rowIndex, 4].NumberValue = countryInfo[i].Area;
                       destSheet.Range[rowIndex, 5].NumberValue = countryInfo[i].Population;
                       destSheet.Pictures.Add(rowIndex, 6, countryInfo[i].Flag);
                       rowIndex++;
                    }
                    
                                //set style
                    destSheet = SetStyle(destBook, destSheet);
        
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
    
            }
        }
    
    **The class i defined:**
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Spire.Xls;
    using System.Drawing;
    
    namespace _4SeriersChart
    {
        public class Country:IComparable<Country>
        {
            public string Name { get; set; }
            public string Capital { get; set; }
            public string Continent { get; set; }
            public float Area { get; set; }
            public float Population { get; set; }
            public Image Flag { get; set; }
    
            public static Comparison<Country> compare =
                    delegate(Country p1, Country p2)
                    {
                        if( p1.Continent.CompareTo(p2.Continent)==0)
                        {
                            return p1.Name.CompareTo(p2.Name);
                        }
                        else
                             return p1.Continent.CompareTo(p2.Continent);
                    };
    
    
            #region IComparable<Country> Members
    
            public int CompareTo(Country other)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    }
