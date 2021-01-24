    public class SomeDTO
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public List<LabelArticles> Labels { get; set; }
        public List<Orders> Orders { get; set; }
    }
    var orderArticlesLabels = result.Select(x => new SomeDTO()
    {     
       
         x.Order.OrderArticles.Select(v => new
         {
           ArticleId = v.ArticleId,
           Name = v.Article.Name,
           Labels = v.Article.LabelArticles.Select(k => new
            {
               LabelId= k.LabelId,
               Name= k.Label.Name
             }),             
            Orders = new List<Order>() {new Order() {Id = x.Order.Id,OrderNumber=x.Order.OrderNumber }}
        })
    });
