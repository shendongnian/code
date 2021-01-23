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
    
