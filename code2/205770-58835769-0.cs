        public static byte[] MergePDFs(List<byte[]> lPdfByteContent)
        {
            using (MemoryStream oMemoryStream = new MemoryStream())
            {
                using (PdfWriter oWriter = new PdfWriter(oMemoryStream))
                {
                    oWriter.SetSmartMode(true);
                    using (PdfDocument oMergedPdf = new PdfDocument(oWriter))
                    {
                        PdfMerger oMerger = new PdfMerger(oMergedPdf, false, false);
                        for (int i = 0; i < lPdfByteContent.Count; i++)
                        {
                            PdfDocument oPdfAux = new PdfDocument(new PdfReader(new MemoryStream(lPdfByteContent[i])));
                            oMerger.SetCloseSourceDocuments(true).Merge(oPdfAux, 1, oPdfAux.GetNumberOfPages());
                        }
                    }
                }
                return oMemoryStream.ToArray();
            }
        }
