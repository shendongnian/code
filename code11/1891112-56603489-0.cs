    Stream StreamFromDropbox = await response.GetContentAsStreamAsync();         
    
    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    MemoryStream StreamFromDropboxCopyAsync = new MemoryStream();
    await StreamFromDropbox.CopyToAsync(StreamFromDropboxCopyAsync);
    StreamFromDropboxCopyAsync.Seek(offset: 0, loc: SeekOrigin.Begin);
    IExcelDataReader reader = ExcelDataReader.ExcelReaderFactory.CreateOpenXmlReader(StreamFromDropboxCopyAsync, new ExcelReaderConfiguration() { FallbackEncoding = System.Text.Encoding.GetEncoding(1252) });
    DataSet result = reader.AsDataSet();
