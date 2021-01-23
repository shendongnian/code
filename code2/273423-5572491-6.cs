    private static string getWorkbookTemplate()
    {
        StringBuilder sb = new StringBuilder(818);
        sb.AppendFormat(@"<?xml version=""1.0""?>{0}", Environment.NewLine);
        sb.AppendFormat(@"<?mso-application progid=""Excel.Sheet""?>{0}", Environment.NewLine);
        sb.AppendFormat(@"<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:o=""urn:schemas-microsoft-com:office:office""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:x=""urn:schemas-microsoft-com:office:excel""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""{0}", Environment.NewLine);
        sb.AppendFormat(@" xmlns:html=""http://www.w3.org/TR/REC-html40"">{0}", Environment.NewLine);
        sb.AppendFormat(@" <Styles>{0}", Environment.NewLine);
        sb.AppendFormat(@"  <Style ss:ID=""Default"" ss:Name=""Normal"">{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Alignment ss:Vertical=""Bottom""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Borders/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Font ss:FontName=""Verdana"" x:Family=""Swiss"" ss:Size=""12"" ss:Color=""#0000A0""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Interior/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <NumberFormat/>{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Protection/>{0}", Environment.NewLine);
        sb.AppendFormat(@"  </Style>{0}", Environment.NewLine);
        sb.AppendFormat(@"  <Style ss:ID=""s62"">{0}", Environment.NewLine);
        sb.AppendFormat(@"   <Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""{0}", Environment.NewLine);
        sb.AppendFormat(@"    ss:Bold=""1""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"  </Style>{0}", Environment.NewLine);
        sb.AppendFormat(@"  <Style ss:ID=""s63"">{0}", Environment.NewLine);
        sb.AppendFormat(@"   <NumberFormat ss:Format=""Short Date""/>{0}", Environment.NewLine);
        sb.AppendFormat(@"  </Style>{0}", Environment.NewLine);
        sb.AppendFormat(@" </Styles>{0}", Environment.NewLine);
        sb.Append(@"{0}\r\n</Workbook>");
        return sb.ToString();
    }
    
    private static string replaceXmlChar(string input)
    {
        input = input.Replace("&", "&amp");
        input = input.Replace("<", "&lt;");
        input = input.Replace(">", "&gt;");
        input = input.Replace("\"", "&quot;");
        input = input.Replace("'", "&apos;");
        return input;
    }
    
    private static string getCell(Type type, object cellData)
    {
        Object data = (cellData is DBNull) ? "" : cellData;
        if (type.Name.Contains("Int") || type.Name.Contains("Double") || type.Name.Contains("Decimal")) return string.Format("<Cell><Data ss:Type=\"Number\">{0}</Data></Cell>", data);
        if (type.Name.Contains("Date") && data.ToString() != string.Empty)
        {
            return string.Format("<Cell ss:StyleID=\"s63\"><Data ss:Type=\"DateTime\">{0}</Data></Cell>", Convert.ToDateTime(data).ToString("yyyy-MM-dd"));
        }
        return string.Format("<Cell><Data ss:Type=\"String\">{0}</Data></Cell>", replaceXmlChar(data.ToString()));
    }
    private static string getWorksheets(DataSet source)
    {
        StringWriter sw = new StringWriter();
        if (source == null || source.Tables.Count == 0)
        {
            sw.Write("<Worksheet ss:Name=\"Sheet1\">\r\n<Table>\r\n<Row><Cell><Data ss:Type=\"String\"></Data></Cell></Row>\r\n</Table>\r\n</Worksheet>");
            return sw.ToString();
        }
        foreach (DataTable dt in source.Tables)
        {
            if (dt.Rows.Count == 0)
                sw.Write("<Worksheet ss:Name=\"" + replaceXmlChar(dt.TableName) + "\">\r\n<Table>\r\n<Row><Cell  ss:StyleID=\"s62\"><Data ss:Type=\"String\"></Data></Cell></Row>\r\n</Table>\r\n</Worksheet>");
            else
            {
                //write each row data                
                int sheetCount = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((i % rowLimit) == 0)
                    {
                        //add close tags for previous sheet of the same data table
                        if ((i / rowLimit) > sheetCount)
                        {
                            sw.Write("\r\n</Table>\r\n</Worksheet>");
                            sheetCount = (i / rowLimit);
                        }
                        sw.Write("\r\n<Worksheet ss:Name=\"" + replaceXmlChar(dt.TableName) +
                                 (((i / rowLimit) == 0) ? "" : Convert.ToString(i / rowLimit)) + "\">\r\n<Table>");
                        //write column name row
                        sw.Write("\r\n<Row>");
                        foreach (DataColumn dc in dt.Columns)
                            sw.Write(string.Format("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">{0}</Data></Cell>", replaceXmlChar(dc.ColumnName)));
                        sw.Write("</Row>");
                    }
                    sw.Write("\r\n<Row>");
                    foreach (DataColumn dc in dt.Columns)
                        sw.Write(getCell(dc.DataType, dt.Rows[i][dc.ColumnName]));
                    sw.Write("</Row>");
                }
                sw.Write("\r\n</Table>\r\n</Worksheet>");
            }
        }
    
        return sw.ToString();
    }
    public static string GetExcelXml(DataTable dtInput, string filename)
    {
        string excelTemplate = getWorkbookTemplate();
        DataSet ds = new DataSet();
        ds.Tables.Add(dtInput.Copy());
        string worksheets = getWorksheets(ds);
        string excelXml = string.Format(excelTemplate, worksheets);
        return excelXml;
    }
    
    public static string GetExcelXml(DataSet dsInput, string filename)
    {
        string excelTemplate = getWorkbookTemplate();
        string worksheets = getWorksheets(dsInput);
        string excelXml = string.Format(excelTemplate, worksheets);
        return excelXml;
    }
    
    public static void ToExcel(DataSet dsInput, string filename, HttpResponse response)
    {
        string excelXml = GetExcelXml(dsInput, filename);
        response.Clear();
        response.AppendHeader("Content-Type", "application/vnd.ms-excel");
        response.AppendHeader("Content-disposition", "attachment; filename=" + filename);
        response.Write(excelXml);
        response.Flush();
        response.End();
    }
    
    public static void ToExcel(DataTable dtInput, string filename, HttpResponse response)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(dtInput.Copy());
        ToExcel(ds, filename, response);
    }
