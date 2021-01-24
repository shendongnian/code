    var articles = (from Article in result
                     select new object[]
                  {        // Could get this values from column headers? 
                                    $"\"{Article.ArticleName}\"",
                                    $"\"{Article.Price}\"",
                                    $"\"{Article.ArticleType}\"",
                                    $"{(Article.Active==true ? "Active" : "Inactive")}",
                  }).ToList();
