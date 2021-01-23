    using System.Collections.Generic;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    namespace PDFLib.PageEvents
    { 
        public class CustomPageEvent : PdfPageEventHelper
        {
            private int _page;
            private readonly Rectangle _marges;
            private string _text;
            
            private static readonly Font FontHf = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 9);
            private readonly Dictionary<int, float> _posicions;
            public CustomPageEvent(string text){
                _text = text;
                _marges = new Rectangle(10, 10, _pageSize.Width - 20, _pageSize.Height - 20);
                _posicions = new Dictionary<int, float>
                             {
                                 {Element.ALIGN_LEFT, _marges.Left + 10},
                                 {Element.ALIGN_RIGHT, _marges.Right - 10},
                                 {Element.ALIGN_CENTER, (_marges.Left + _marges.Right)/2}
                             };
            }
            public override void OnStartPage(PdfWriter writer, Document document)
            {
                _page++;
                
                base.OnStartPage(writer, document);
            }
    
            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                _page = 0;
            }
    
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                if (page==1)
                    ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, new Phrase(string.Format("{0}", _text), FontHf), _posicions[Element.ALIGN_CENTER], _marges.Top-10, 0);
                
                base.OnEndPage(writer,document);
            }
 
        }
    }
