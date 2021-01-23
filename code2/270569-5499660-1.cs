    public class TextLineObj
    {
        public ReadonlyCollection<TextLine> TextLines { get; private set; }
        
        public TextLineObj()
        {
            TextLines = new ReadonlyCollection<TextLine>(
                                new List<TextLine> { TextLine1, TextLine2, 
                                                     TextLine3, TextLine4 });
        }
    }
