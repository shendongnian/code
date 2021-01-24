    Article = db.TestArtikel.Where(x => x.Name == "test1").SingleOrDefault();
    public static void AnotherFunction()
    {
     using (DbEntities db = new DbEntities())
     {
         db.TestProduct.Add(new TestProduct()
            {
                ProductId = Guid.NewGuid(),
                Price = 10,
                DeliveryDate = DateTime.Now,
                ArticleId = Article.ArticleId
            });
         db.SaveChanges();
      }
    }
