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
