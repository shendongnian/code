    List<category> categoryWithParents = new List<category>();
    protected void load_categories(List<category> list, category item)
    {
        foreach(category cat in list)
        {
           if(item.id == cat.id)
           {
             categoryWithParents.Add(cat);
             if(cat.parentid != null) //if category has parent
               load_categories(list, cat); //load that parent
             break; //adding break should stop looping because we found category
           }
        }
    }
