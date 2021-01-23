    private void OpenXmlFileHandling(String fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, true))
            {
                //some sample values
                String definedName = "Worksheet3";
                String topLeft = "$A$3";
                String bottomRight = "$D$7";
                WorkbookPart wbPart = document.WorkbookPart;
                var definedNames = wbPart.Workbook.Descendants<DefinedNames>().FirstOrDefault();
                var namesCollection = definedNames.Descendants<DefinedName>().Where(m => m.Text.StartsWith(definedName));
                DefinedName name = namesCollection != null ? namesCollection.First() : null;
                UInt32Value locSheetId = name.LocalSheetId;
                name.Remove();
                wbPart.Workbook.Save();
                name = new DefinedName() { Name = "_xlnm.Print_Area", LocalSheetId = locSheetId, Text = String.Format("{0}!{1}:{2}", definedName, topLeft, bottomRight) };
                definedNames.Append(name);
                wbPart.Workbook.Save();
            }
        }
