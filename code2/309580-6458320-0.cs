    [ServiceContract]
    public interface IMSDNMagazineService
    {
        [OperationContract]
        [WebGet(UriTemplate="/")]
        IssuesCollection GetAllIssues();
        [OperationContract]
        [WebGet(UriTemplate = "/{year}")]
        IssuesData GetIssuesByYear(string year);
        [OperationContract]
        [WebGet(UriTemplate = "/{year}/{issue}")]
        Articles GetIssue(string year, string issue);
        [OperationContract]
        [WebGet(UriTemplate = "/{year}/{issue}/{article}")]
        Article GetArticle(string year, string issue, string article);
        [OperationContract]
        [WebInvoke(UriTemplate = "/{year}/{issue}",Method="POST")]
        Article AddArticle(string year, string issue, Article article);
    }
