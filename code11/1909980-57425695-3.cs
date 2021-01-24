    List<ClassificationWithLanguageViewModel> classificationOne1Language = 
                                              await (from c in _context.Classification
                                              join l in _context.ClassificationLanguage
                                              on c.SuClassificationId equals l.SuClassificationId
                                              select new ClassificationWithLanguageViewModel 
                                              { 
                                                SuClassificationId = c.SuClassificationId,
                                                SuClassificationName =  l.SuClassificationName 
                                              }).ToListAsync();
          
    foreach (var c in classificationOne1Language)
    {
      
    }
