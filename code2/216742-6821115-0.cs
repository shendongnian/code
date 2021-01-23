        public partial class YourTypeNameEntities
    {
        partial void OnContextCreated()
        {
            this.MetadataWorkspace.LoadFromAssembly(typeof(Full.Namespace.Of.YourTypeNameEntities).Assembly);
        }
