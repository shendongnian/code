    var drillDownQuery = new DrillDownQuery(facetsConfig, baseQuery);
    
    var boolQuery = new BooleanQuery();
    boolQuery.Add(new TermQuery(new Term("Ingredient", "Chocolate")), Occur.MUST);
    boolQuery.Add(new TermQuery(new Term("Ingredient", "Nuts")), Occur.MUST);
    drillDownQuery.Add("Ingredient", boolQuery);
