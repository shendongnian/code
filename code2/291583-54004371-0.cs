        public static byte[] MergePDFs(List<byte[]> pdfFiles)
        {  
            if (pdfFiles.Count > 1)
            {
                PdfReader finalPdf;
                Document pdfContainer;
                PdfWriter pdfCopy;
                MemoryStream msFinalPdf = new MemoryStream();
                finalPdf = new PdfReader(pdfFiles[0]);
                pdfContainer = new Document();
                pdfCopy = new PdfSmartCopy(pdfContainer, msFinalPdf);
                pdfContainer.Open();
                for (int k = 0; k < pdfFiles.Count; k++)
                {
                    finalPdf = new PdfReader(pdfFiles[k]);
                    for (int i = 1; i < finalPdf.NumberOfPages + 1; i++)
                    {
                        ((PdfSmartCopy)pdfCopy).AddPage(pdfCopy.GetImportedPage(finalPdf, i));
                    }
                    pdfCopy.FreeReader(finalPdf);
                }
                finalPdf.Close();
                pdfCopy.Close();
                pdfContainer.Close();
                return msFinalPdf.ToArray();
            }
            else if (pdfFiles.Count == 1)
            {
                return pdfFiles[0];
            }
            return null;
        }
