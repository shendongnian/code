    protected void btnUpload_Click(object sender, EventArgs e)
            {
                if (fuPDFUpload.HasFile)
                {
                    PdfReader reader = new PdfReader(fuPDFUpload.FileBytes);
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        lblPdfText.Text += PdfTextExtractor.GetTextFromPage(reader, i);    
                    }
                    
                }
            }
