    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property),
     MetadataAttribute]
    public class ExportDocumentViewerAttribute : ExportAttribute, IDocumentViewerMetadata
    {
      public ExportDocumentViewer(string name, bool supportsEditing, params DocFormat[] formats)
        : base(typeof(IDocumentViewer))
      {
        if (string.IsNullOrEmpty(name))
          throw new ArgumentException("Export requires a name", "name");
          
        Name = name;
        SupportsEditing = supportsEditing;
        Formats = formats ?? Enumerable.Empty<DocFormat>();
      }
      
      public string Name { get; private set; }
      
      public bool SupportsEditing { get; private set; }
      
      public IEnumerable<DocFormat> Formats { get; private set; }
    }
    
    [ExportDocumentViewer("Word", true, DocFormat.DOC, DocFormat.DOCX)]
    public WordDocumentViewer : IDocumentViewer
    {
      // Stuff
    }
