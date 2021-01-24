    using PdfSharp.Pdf;
    using PdfSharp.Pdf.Annotations;
    using System;
    using System.Linq;
    using System.Reflection;
    
    internal sealed class MyPdfSignatureField : PdfAnnotation
    {
        public MyPdfSignatureField(PdfDocument document, PdfRectangle rect) : base(document)
        {
            Elements.Add("/FT", new PdfName("/Sig"));
            Elements.Add(Keys.T, new PdfString("Signature1"));
            Elements.Add("/Ff", new PdfInteger(132));
            Elements.Add("/DR", new PdfDictionary());
            Elements.Add(Keys.Subtype, new PdfName("/Widget"));
            Elements.Add("/P", document.Pages[0]);
            PdfDictionary sign = new PdfDictionary(document);
            sign.Elements.Add(Keys.Type, new PdfName("/Sig"));
            sign.Elements.Add("/Filter", new PdfName("/Adobe.PPKLite"));
            sign.Elements.Add("/SubFilter", new PdfName("/adbe.pkcs7.detached"));
            sign.Elements.Add(Keys.M, new PdfDate(DateTime.Now));
            var irefTable = document
                .GetType()
                .GetField("_irefTable", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(document);
            var irefTableAdd = irefTable
                .GetType()
                .GetMethods()
                .Where(m => m.Name == "Add").Skip(1).FirstOrDefault();
            irefTableAdd.Invoke(irefTable, new object[] { sign });
            Elements.Add("/V", sign);
            Elements.Add("/Rect", rect);
            Flags = PdfAnnotationFlags.Print;
            Opacity = 1;
        }
    }
