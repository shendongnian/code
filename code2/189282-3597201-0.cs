    class foo {
     MaxPrice {get; set;}
     CountAll {get; set;}
    }
    
    var list = OpenSession()
                  .CreateQuery("SELECT MAX(p.price) as max_price, 
                                       COUNT(p.id) as count_all 
                                FROM Order o left join o.Products p)
                  .List<foo>();
