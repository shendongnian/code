    if (MyCollection.Any())
    {
        if (page * itemsPerPage > MyCollection.Count)
        {
            page = MyCollection.Count / 3;
        }
        else if (page < 1) 
        {
            page = 1;
        }
        MyCollection.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
    }
