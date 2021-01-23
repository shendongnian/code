        public static List<System.Drawing.Image> ExtractImagesFromPDF(byte[] bytes)
        {
            var imgs = new List<System.Drawing.Image>();
            var pdf = new PdfReader(bytes);
            try
            {
                for (int pageNumber = 1; pageNumber <= pdf.NumberOfPages; pageNumber++)
                {
                    PdfDictionary pg = pdf.GetPageN(pageNumber);
                    List<PdfObject> objs = FindImageInPDFDictionary(pg);
                    foreach (var obj in objs)
                    {
                        if (obj != null)
                        {
                            int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                            PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                            PdfStream pdfStrem = (PdfStream)pdfObj;
                            var pdfImage = new PdfImageObject((PRStream)pdfStrem);
                            var img = pdfImage.GetDrawingImage();
                            imgs.Add(img);
                        }
                    }
                }
            }
            finally
            {
                pdf.Close();
            }
            return imgs;
        }
        private static List<PdfObject> FindImageInPDFDictionary(PdfDictionary pg)
        {
            var res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
            var xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
            var pdfObgs = new List<PdfObject>();
            if (xobj != null)
            {
                foreach (PdfName name in xobj.Keys)
                {
                    PdfObject obj = xobj.Get(name);
                    if (obj.IsIndirect())
                    {
                        var tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                        var type = (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));
                        if (PdfName.IMAGE.Equals(type)) // image at the root of the pdf
                        {
                            pdfObgs.Add(obj);
                        }
                        else if (PdfName.FORM.Equals(type)) // image inside a form
                        {
                            FindImageInPDFDictionary(tg).ForEach(o => pdfObgs.Add(o));
                        }
                        else if (PdfName.GROUP.Equals(type)) // image inside a group
                        {
                            FindImageInPDFDictionary(tg).ForEach(o => pdfObgs.Add(o));
                        }
                    }
                }
            }
            return pdfObgs;
        }
