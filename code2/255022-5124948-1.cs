    Cell cell = GetCell(worksheet, "A", 1);
        
    string cellValue = string.Empty;
    
    if (cell.DataType != null)
    {
        if (cell.DataType == CellValues.SharedString)
        {
           int id = -1;
        
           if (Int32.TryParse(cell.InnerText, out id))
           {
               SharedStringItem item = GetSharedStringItemById(workbookPart, id);
    
               if (item.Text != null)
               {
                   cellValue = item.Text.Text;
               }
               else if (item.InnerText != null)
               {
                   cellValue = item.InnerText;
               }
               else if (item.InnerXml != null)
               {
                   cellValue = item.InnerXml;
               }
           }
        }
    }
