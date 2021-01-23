    using Sitecore.Data;
    using Sitecore.Data.Indexing;
    using Sitecore.Diagnostics;
    
    namespace MyProject.Lib.Search.Indexing
    {
      public class CustomIndex : Index
      {
        public CustomIndex(string name)
          : base(name)
        {
        }
    
        public override void Rebuild(Database database)
        {
          Sitecore.Search.Index index = Sitecore.Search.SearchManager.GetIndex(Name);
          if (index != null)
          {
            index.Rebuild();
          }
        }
      }
    }
