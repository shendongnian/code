    public class BasePage : SubclassMap<IPage> //IPage could inherit: IMultiTaggedPage, ISearchablePage
    {
        public BasePage()
        {
            Map(x => x.Text, "Text");
            // coming from IMultiTaggedPage
            HasManyToMany(x => x.Tags).Table("PageTags").ParentKeyColumn("PageId").ChildKeyColumn("TagId").Cascade.SaveUpdate();
            // coming from ISearchablePage
            Map(x => ((ISearchablePage)x).SearchIndex, "SearchIndex").LazyLoad();
        }
    }
    public class PostMapping : BasePage
    {
        public PostMapping()  // don't need to specify : base() because it happens automatically
        {
            Table("the specific table");
            HasManyToMany(x => x.Categories).Table("PageCategories").ParentKeyColumn("PageId").ChildKeyColumn("CategoryId").Cascade.SaveUpdate();
            //Other table specific mappings:
        }
    }
