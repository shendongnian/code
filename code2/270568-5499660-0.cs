    public class TextLineObj
    {
        public ReadonlyCollection TextLines { get; private set; }
        
        public TextLineObj()
        {
            TextLines = new ReadonlyCollection { TextLine1, TextLine2, 
                                                 TextLine3, TextLine4 };
        }
    }
