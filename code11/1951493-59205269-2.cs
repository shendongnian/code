    List<Product> GetProductsFromSearch(int languageId, string searchedData){
       if (string.IsNullOrEmpty(searchedData))
           return new List<Product>();
    
       var query = _contex.Products.ToList(); 
    
        switch(languageId) //LanguageId 1 = English , LangaugeId 2 = Italian
        {
           case 1:
                query = query.Where(i=> !string.IsNullOrEmpty(i.NameEnglish) && i.NameEnglish.Contains(searchedData));
           case 2:
                query = query.Where(i=> !string.IsNullOrEmpty(i.NameItalian) && i.NameItalian.Contains(searchedData));
        }
    
        return query.ToList();
    }
