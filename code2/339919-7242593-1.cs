                using (MemoryStream stream = new MemoryStream())
                {
                    // create in-memory copy of the Excel template file
                    byte[] byteArray = File.ReadAllBytes(TEMPLATE_FILE_NAME);
                    stream.Write(byteArray, 0, (int)byteArray.Length);
    
                    using (SpreadsheetDocument document = SpreadsheetDocument.Open(stream, true))
                    {
                        // Set private variable template component references (for reuse between methods)
                        mExcelWorkbookPart = document.WorkbookPart;
                        mSharedStringTablePart = mExcelWorkbookPart.SharedStringTablePart;
                       
                        mSharedStringTablePart.SharedStringTable.AppendChild(GenerateSharedStringItem());
                    }
    
                    return stream.ToArray();
                }
