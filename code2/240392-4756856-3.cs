    DataRow[] aDr = row.GetChildRows("EventCategoryRelation");
    var categoryList = aDr.Select(row => new Categories()
                                  {
                                     category.CategoryID = Int64.Parse(dr["category_id"].ToString());
                                  });
    // add them to your event
    events.CategoryList.AddRange(categoryList);
    // or ...
    events.CategoryList = categoryList.ToList();
