    public static IEnumerable<SelectListItem> GetCategories()
        {
            // your context
            return new SelectList(myContext.Categories.OrderBy(x => x.NameCategory ), 
                                                          "IdCategory ", "NameCategory ");
        }
