    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    private string partData = "...";
        public void vbaInjector{    
            [code to create / open spreadsheet using OpenXML omitted]
            VbaProjectPart vbaProjectPart1 = snoreSpreadsheetDoc.WorkbookPart.AddNewPart<VbaProjectPart>("rId8");
            System.IO.Stream data = GetBinaryDataStream(partData);
            vbaProjectPart1.FeedData(data);
            data.Close();
            [code to close spreadsheet and cleanup omitted]
        }
        private System.IO.Stream GetBinaryDataStream(string base64String)
        {
            return new System.IO.MemoryStream(System.Convert.FromBase64String(base64String));
        }
