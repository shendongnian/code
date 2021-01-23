    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false), MetadataAttribute]
    public ExportControllerAttribute : ExportAttribute, INameMetadata
    {
        public ExportControllerAttribute(string name)
            : base(typeof(IController))
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
