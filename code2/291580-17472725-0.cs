    protected void Page_Load(object sender, EventArgs e)
    {
        String[] files = @"C:\ENROLLDOCS\A1.pdf,C:\ENROLLDOCS\A2.pdf".Split(',');
        MergeFiles(@"C:\ENROLLDOCS\New1.pdf", files);
    }
    public void MergeFiles(string destinationFile, string[] sourceFiles)
    {
        if (System.IO.File.Exists(destinationFile))
            System.IO.File.Delete(destinationFile);
        string[] sSrcFile;
        sSrcFile = new string[2];
        string[] arr = new string[2];
        for (int i = 0; i <= sourceFiles.Length - 1; i++)
        {
            if (sourceFiles[i] != null)
            {
                if (sourceFiles[i].Trim() != "")
                    arr[i] = sourceFiles[i].ToString();
            }
        }
        if (arr != null)
        {
            sSrcFile = new string[2];
            for (int ic = 0; ic <= arr.Length - 1; ic++)
            {
                sSrcFile[ic] = arr[ic].ToString();
            }
        }
        try
        {
            int f = 0;
            PdfReader reader = new PdfReader(sSrcFile[f]);
            int n = reader.NumberOfPages;
            Response.Write("There are " + n + " pages in the original file.");
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage page;
            int rotation;
            while (f < sSrcFile.Length)
            {
                int i = 0;
                while (i < n)
                {
                    i++;
                    document.SetPageSize(PageSize.A4);
                    document.NewPage();
                    page = writer.GetImportedPage(reader, i);
                    rotation = reader.GetPageRotation(i);
                    if (rotation == 90 || rotation == 270)
                    {
                        cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                    }
                    else
                    {
                        cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                    }
                    Response.Write("\n Processed page " + i);
                }
                f++;
                if (f < sSrcFile.Length)
                {
                    reader = new PdfReader(sSrcFile[f]);
                    n = reader.NumberOfPages;
                    Response.Write("There are " + n + " pages in the original file.");
                }
            }
            Response.Write("Success");
            document.Close();
        }
        catch (Exception e)
        {
            Response.Write(e.Message);
        }
        
    }
