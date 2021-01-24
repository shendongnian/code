    using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
        {
            WorkbookPart workbookPart = doc.WorkbookPart;
            SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
            SharedStringTable sst = sstpart.SharedStringTable;
            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            Worksheet sheet = worksheetPart.Worksheet;
            var rows = sheet.Descendants<Row>();
            foreach (Row row in rows)
            {
                int cellIndex = 0;
                foreach (Cell c in row.Elements<Cell>())
                {
                    if ((c.DataType != null) && (c.DataType == CellValues.SharedString))
                    {
                        int ssid = int.Parse(c.CellValue.Text);
                        string str = sst.ChildElements[ssid].InnerText;
                        if (str == "Date of birth:")
                        {
                            Cell next_cell = row.Descendants<Cell>().ElementAt(cellIndex + 1);
                            MessageBox.Show(next_cell.CellValue.Text);
                        }
                    }
                    cellIndex++;
                }
            }
        }
    }
