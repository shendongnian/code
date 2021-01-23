     public class PageEventHelper : PdfPageEventHelper
        {
            PdfContentByte cb;
            PdfTemplate template;
            private int TotalNumber = 0;
           
            //for remeber lastpage
            public void SetNumber(int num)
            {
                TotalNumber = num;
            }
            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                cb = writer.DirectContent;
                template = cb.CreateTemplate(50, 50);
            }
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);
                cb = writer.DirectContent;
                template = cb.CreateTemplate(50, 50);
                BaseFont font = BaseFont.CreateFont();
                int pageN = writer.PageNumber;
                String text = pageN.ToString();
                float len = font.GetWidthPoint(text, 9);
               
                iTextSharp.text.Rectangle pageSize = document.PageSize;
               // cb.SetRGBColorFill(100, 100, 100);
                
                ;
                cb.BeginText();
                cb.SetFontAndSize(font, 9);
                cb.SetTextMatrix(document.LeftMargin, pageSize.GetBottom(document.BottomMargin));
                //cb.ShowText(text);
                
                if (pageN > 1 && TotalNumber==0)
                {
                    cb.ShowTextAligned(Element.ALIGN_CENTER, (pageN - 6).ToString() , 300f, 10f, 0);
                }
                cb.EndText();
                cb.AddTemplate(template, document.LeftMargin + len, pageSize.GetBottom(document.BottomMargin));
            }
    }
