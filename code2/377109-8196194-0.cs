    public class Section
    {
      public String Head { get; set; }
      private readonly List<string> _subHead = new List<string>();
      private readonly List<string> _content = new List<string>();
      public IEnumerable<string> SubHead { get { return _subHead; } }
      public IEnumerable<string> Content { get { return _content; } }
      public void AddContent(String argValue)
      {
        _content.Add(argValue);
      }
      public void AddSubHeader(String argValue)
      {
        _subHead.Add(argValue);
      }
    }
