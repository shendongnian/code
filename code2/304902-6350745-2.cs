    [AttributeUsage(AttributeTargets.Class), MetadataAttribute]
    public class ExportMessageSenderAttribute : Attribute, INameMetadata
    {
      public ExportMessageSenderAttribute(string name)
        : base(typeof(IMessageSender))
      {
        Name = name;
      }
      
      public string Name { get; private set; }
    }
