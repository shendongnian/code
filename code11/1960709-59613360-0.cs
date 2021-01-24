`  
 public static SpreadsheetGear.IWorkbook GetObjectFromS3AndReturnWorkbook(string key, string path, string bucketName)
        {
            GetObjectResponse response = client.GetObject(bucketName, key);
            MemoryStream memoryStream = new MemoryStream();
            using (Stream responseStream = response.ResponseStream)
            {
                responseStream.CopyTo(memoryStream);
            }
            IWorkbookSet workbookSet = Factory.GetWorkbookSet();
            SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.OpenFromStream(memoryStream);
            return workbook;
        }
`
