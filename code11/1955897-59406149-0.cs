    public interface IAssetsDefaultSearchResult : ISearchResultBase
    {
    	new ISearchModelBase SearchModel { get; }
    
    	string DisplayName { get; }
    
    	object Data { get; }
    
    	TagBuilder HtmlTag { get; }
    }
