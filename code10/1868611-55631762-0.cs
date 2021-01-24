    public class PdfFileInfo
    {
        public string Filename { get; set; }
        public int PageCount { get; set; }
    }
    private void GetPdfFiles(string folder)
    {
    	var pdfFileInfos = new List<PdfFileInfo>();
    	
    	var filePaths = Directory.GetFiles(folder, "*.pdf", SearchOption.AllDirectories);
    
    	foreach (var filePath in filePaths)
    	{
    		pdfFileInfos.Add(new PdfFileInfo
    		{
    			Filename = filePath,
    			PageCount = GetNumberOfPdfPages(filePath)
    		});
    	}
    
    	pdfFileInfos = pdfFileInfos.OrderBy(x => x.PageCount).ToList();
    
    	if (pdfFileInfos.Count > 1)
    	{
    		var result = pdfFileInfos[0];
    
    		MessageBox.Show($"{result.Filename} has {result.PageCount} pages.");
    	}
    }
