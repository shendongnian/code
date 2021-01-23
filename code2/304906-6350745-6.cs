    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false), MetadataAttribute]
    public class ExportMessageSenderAttribute : ExportAttribute, INameMetadata
    {
      public ExportMessageSenderAttribute(string name)
        : base(typeof(IMessageSender))
      {
        Name = name;
      }
      
      public string Name { get; private set; }
    }
