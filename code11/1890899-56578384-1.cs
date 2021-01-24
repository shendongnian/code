       Public ActionResult Index(string searchString)
        {
         var query1 = (from c in db.TableArticle select c);
           if (!String.IsNullOrEmpty(searchString))
             {
        query1 = query1.Where(s => 
                s.Article_Title.Contains(searchString)
        || s.Article_Description.Contains(searchString) || 
                 s.Written_By.Contains(searchString) || 
                 s.Organisation.Contains(searchString)
       ||s.Source.Contains(searchString));
                }
        var query2 = (.......);
        var query3 = (.......);
    
        var finalResult = query1.Select(x => x.columnName).Union(query2.Select(x => x.columnName)).Union(query3.Select(x => x.columnName));
        // OR
        var finalResult = query1.Select(x => x.columnName).Concat(query2.Select(x => x.columnName)).Concat(query3.Select(x => x.columnName));
        }
