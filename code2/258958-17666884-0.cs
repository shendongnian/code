        /// <summary>
        /// Saves as.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void SaveAs(String filename)
        {
            String dir = filename.Replace(System.IO.Path.GetFileName(filename), String.Empty);
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);
 
            SpreadsheetDocument newDoc = SpreadsheetDocument.Create(filename, Document.DocumentType);
 
            //Make sure it's clear
            newDoc.DeleteParts<OpenXmlPart>(newDoc.GetPartsOfType<OpenXmlPart>());
 
            //Copy all parts into the new book
            foreach (OpenXmlPart part in Document.GetPartsOfType<OpenXmlPart>())
            {
                OpenXmlPart newPart = newDoc.AddPart<OpenXmlPart>(part);
            }
           
            //Perform 'save as'
            newDoc.WorkbookPart.Workbook.Save();
            newDoc.Close();
            this.Document.Close();
 
            //Open new doc
            this.Document = SpreadsheetDocument.Open(filename, true);
        }
