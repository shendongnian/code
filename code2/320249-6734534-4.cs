    // make sure there are any items and that itemsPerPage is greater than zero
    // to prevent any DivideByZeroExeceptions from being thrown
    if (MyCollection.Any() && itemsPerPage > 0)
    {
        if (page * itemsPerPage > MyCollection.Count)
        {
            // if page is past collection change to the last page
            page = (int)Math.Ceiling((float)MyCollection.Count / (float)itemsPerPage);
        }
        else if (page < 1) 
        {
            // if page is before collection change to 1
            page = 1;
        }
        // skip pages and select the number of pages
        MyCollection.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
    }
