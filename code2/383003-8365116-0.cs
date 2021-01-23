    private void GenerateSpreadsheet(string id, string csv, string worksheetName)
    {
        using (ExcelPackage pck = new ExcelPackage())
        {
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add(worksheetName);
 
            ws.Cells["A1"].LoadFromText(csv, new ExcelTextFormat { Delimiter = '|', 
                DataTypes = new eDataTypes[] { eDataTypes.String, eDataTypes.String, 
                    eDataTypes.String, eDataTypes.String, eDataTypes.String,
                    eDataTypes.String, eDataTypes.String, eDataTypes.String,
                    eDataTypes.String, eDataTypes.String, eDataTypes.String, 
                    eDataTypes.String, eDataTypes.String, eDataTypes.String } }); 
 
            Response.AddHeader("Content-Disposition",
                String.Format("attachment; filename={0}.xlsx", id));
            Response.ContentType =
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
    }
