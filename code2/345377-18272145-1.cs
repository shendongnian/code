    private static void ReplacePDFCreator(PdfWriter writer)
        {
            Type writerType = writer.GetType();
            PropertyInfo writerProperty = writerType.GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).Where(p => p.PropertyType == typeof(PdfDocument)).FirstOrDefault();
            PdfDocument pd =  (PdfDocument)writerProperty.GetValue(writer);
            Type pdType = pd.GetType();
            FieldInfo infoProperty = pdType.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).Where(p => p.Name == "info").FirstOrDefault();
            PdfDocument.PdfInfo pdfInfo = (PdfDocument.PdfInfo)infoProperty.GetValue(pd);
            PdfString str = new PdfString("YOUR NEW PDF CREATOR HERE");
            pdfInfo.Remove(new PdfName("Producer"));
            pdfInfo.Put(new PdfName("Producer"), str);
        }
