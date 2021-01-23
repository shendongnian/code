    var eventsList = eventsTable.Rows.Select(eventRow => new Events()
      {
         Description = eventRow["event_description"].ToString(),
         CategoryList = eventRow.GetChildRows("EventCategoryRelation")
                                .Select(row => new Categories()
                                  {
                                     category.CategoryID = Int64.Parse(dr["category_id"].ToString());
                                  })
                                .ToList()
      }
