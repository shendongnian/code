    var choiceVals = new []{ "Cat1", "Cat2"};
                    
    await graphClient.Sites[siteId].Lists[listId].Items[itemId].Request().UpdateAsync(new ListItem()
    {
          Fields = new FieldValueSet
          {
                AdditionalData = new Dictionary<string, object>
                {
                    { "Categories@odata.type", "Collection(Edm.String)" },
                    { "Categories", choiceVals }
                }
          }
     }); 
