    [WebMethod]
    public List<TEST.Models.ArticleModel> GetArticles(string terminalSerial)
    {
    
    //..... your code here
    
    System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
    List<TEST.Models.ArticleModel> theList = articles.ToList();
    file.WriteLine("you have "+ theList.Count );
    for(ArticleModel articleModel : theList)
       file.WriteLine(articleModel.ToString());
    
    file.Close();
    }
