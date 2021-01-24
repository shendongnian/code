using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    using (var fs = File.OpenRead(filePath))
                    {
                        using (var streamContent = new StreamContent(fs))
                        {
                            using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                            {
                                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                                form.Add(fileContent, "file", Path.GetFileName(filePath));
                                HttpResponseMessage response = await httpClient.PostAsync(url, form);
                            }
                        }
                    }
                }
            }
2. Azure function
 public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            foreach (var file in req.Form.Files) {
             //Process excel file
             /* For example  use sdk : DocumentFormat.OpenXml. 
For more details, please refer to https://docs.microsoft.com/en-us/office/open-xml/how-to-parse-and-read-a-large-spreadsheet
*/
                using (var stream = new MemoryStream()) {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, false)) {
                        WorkbookPart workbookPart = doc.WorkbookPart;
                        SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                        SharedStringTable sst = sstpart.SharedStringTable;
                        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                        Worksheet sheet = worksheetPart.Worksheet;
                        var cells = sheet.Descendants<Cell>();
                        var rows = sheet.Descendants<Row>();
                        log.LogInformation(string.Format("Row count = {0}", rows.LongCount()));
                        log.LogInformation(string.Format("Cell count = {0}", cells.LongCount()));
                       
                    }
                }
            
            }
 return new OkObjectResult("Ok")
}
[![enter image description here][2]][2]
  [1]: https://go.microsoft.com/fwlink/?LinkID=521962&usg=AOvVaw2vd06xWtIxQTTv-3KBpe8y
  [2]: https://i.stack.imgur.com/4W2cz.png
