    string search = "Your Specific Word";
    string inputPath = "input.docx";
    
    // Load Word document.
    var document = DocumentModel.Load(inputPath);
    
    // 1. Get document's pages.
    var pages = document.GetPaginator().Pages;
    
    for (int i = 0, count = pages.Count; i < count; ++i)
    {
        // 2. Read page's text content.
        DocumentModelPage page = pages[i];
        string pageTextContent = page.PageContent.ToText();
    
        // 3. Save page as PDF.
        if (pageTextContent.Contains(search))
        {
            string outputPath = $"{search}_{i}.pdf";
            page.Save(outputPath);
        }
    }
