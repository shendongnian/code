    public void GenerateWorkbookFromDB()
    {
        //Make a copy of the template file
        File.Copy(HttpContext.Current.Server.MapPath("ReportTemplate/test.xlsx"), HttpContext.Current.Server.MapPath("Reports/test.xlsx"), true);
        //Open up the copied template workbook
        using (SpreadsheetDocument myWorkbook = SpreadsheetDocument.Open(HttpContext.Current.Server.MapPath("Reports/test.xlsx"), true))
        {
            WorkbookPart workbookPart = myWorkbook.WorkbookPart;
            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            string origninalSheetId = workbookPart.GetIdOfPart(worksheetPart);
            WorksheetPart replacementPart = workbookPart.AddNewPart<WorksheetPart>();
            string replacementPartId = workbookPart.GetIdOfPart(replacementPart);
            OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
            OpenXmlWriter writer = OpenXmlWriter.Create(replacementPart);
            Row r = new Row();
            Cell c = new Cell();
            string txt = "test";
            c.CellValue = new CellValue(txt.ToString());
            c.DataType = new EnumValue<CellValues>(CellValues.String);
            //v.Text = "test";
            //c.Append(v);
            while (reader.Read())
            {
                if (reader.ElementType == typeof(SheetData))
                {
                    if (reader.IsEndElement)
                        continue;
                    writer.WriteStartElement(new SheetData());
                    for (int row = 0; row < 20; row++)
                    {
                        writer.WriteStartElement(r);
                        for (int col = 0; col < 4; col++)
                        {
                            writer.WriteElement(c);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                else
                {
                    if (reader.IsStartElement)
                        writer.WriteStartElement(reader);
                    else if (reader.IsEndElement)
                        writer.WriteEndElement();
                }
            }
            reader.Close();
            writer.Close();
            try
            {
                Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().Where(s => s.Id.Value.Equals(origninalSheetId)).First();
                sheet.Id.Value = replacementPartId;
                workbookPart.DeletePart(worksheetPart);
            }
            catch (Exception ex) { }
        }
    }
