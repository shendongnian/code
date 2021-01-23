    public class Template
    {
      public virtual int Id { get; private set; }
      public virtual string Name { get; set; }
    
      public static readonly Template Default = new Template() {ID = (int)TemplateEnum.Default, Name = "Default"};
    }
