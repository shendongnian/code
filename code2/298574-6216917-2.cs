        using Sitecore.Data.Items;
        using Sitecore.Search;
        using Sitecore.Search.Crawlers;
        namespace MyProject.Lib.Search.Indexing
        {
          public class CustomCrawler : DatabaseCrawler
          {
            protected override void AddItem(Item item, IndexUpdateContext context)
            {
              if (item["include in search results"] == "1")
              {
                base.AddItem(item, context);
              }
            }
          }
        }
