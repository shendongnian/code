    public partial class SearchResultsScreen : UITableViewController
	{
		
		List<NewsArticle> NewsArticles;
		
		static NSString CellID = new NSString ("MyIdentifier");
	
		public SearchResultsScreen () : base(UITableViewStyle.Grouped)
		{
		}
    }
