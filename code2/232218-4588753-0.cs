    private void OuterMethod()
    {
       switch(something)
       {
           case (int)Enums.SandwichesHoagies.Cheeses:
               HandleCase(product, this.Cheeses);
               break;
           case (int)Enums.SandwichesHoagies.Meats:
               HandleCase(product, this.Meats);
               break;
       }
    }
    
    private void HandleCase<T>(Product product, List<T> list) where T : Ingredient, new()
    {
        if(list.Any(i => i.Id == product.ProductId))
        {
            list.Add(new T {
                Id = product.ProductId,
                Name = product.Name,
                PriceValue = product.PriceValue ?? 0.0;
            });
        }
        else
        {
            list.RemoveAll(i => i.Id == product.ProductId);
        }
    
        //NOTE: this part seems like a bad idea. looks like code smell.
        foreach (var i in list)
        {
            i.Type = string.Empty;
        }
        if (list.Count > 0)
        {
            list.First().Type = "Cheeses:";
        }
    }
