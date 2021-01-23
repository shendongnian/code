    public class ABC {
     public IList<TextFillerDetail> TextFillerDetails        
     { get { return _textfillerDetails; } }        
      public ABC(int capacity)
      {
        _textfillerDetails = new List<TextFiller>(capacity);
      }
    private List<TextFiller> _textfillerDetails;
    }
