    List<ClassificationWithLanguageViewModel> classificationOne1Language = 
                                              (from c in classification
                                              join l in classificationLanguage
                                              on c.SuClassificationId equals l.SuClassificationId
                                              select new ClassificationWithLanguageViewModel 
                                              { 
                                                SuClassificationId = c.SuClassificationId,
                                                SuClassificationName =  l.SuClassificationName 
                                              }).ToList();
          
    foreach (var c in classificationOne1Language)
    {
      
    }
