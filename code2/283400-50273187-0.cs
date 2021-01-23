    public async Task<FileResult> PrintPdfStatements(string fileName)
        {
             var fileContent = await GetFileStreamAsync(fileName);
             var fileContentBytes = ((MemoryStream)fileContent).ToArray();
             return File(fileContentBytes, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }
