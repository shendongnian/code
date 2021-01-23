    class UserStatistics{
     MaxPrice {get; set;}
     CountAll {get; set;}
    }
    
    var list = OpenSession()
                  .CreateQuery("SELECT MAX(p.price) as max_price, 
                                       COUNT(p.id) as count_all 
                                FROM Order o left join o.Products p")
                  .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean(typeof(UserStatistics)))
                  .List<UserStatistics>();
