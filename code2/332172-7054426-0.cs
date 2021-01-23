    public class MyCtrl : TextBox
    {
      private ExtraProperties _extraProps = new ExtraProperties();
    
      public ExtraProperties ExtraProperties
      {
        get { return _extraProps; }
        set { _extraProps = value; }
      }
    }
    
    public class ExtraProperties
    {
      private string _PropertyA = string.Empty;
    
      [Category("Text Properties"), Description("Value for Property A")]
      public string PropertyA {get; set;}
    
      [Category("Text Properties"), Description("Value for Property B")]
      public string PropertyB { get; set; }
    }
