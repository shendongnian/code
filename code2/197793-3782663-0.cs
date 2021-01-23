    // fill this in
    int pageSize = 10;
    // This figures out the total number of pages for you. The modulo stuff
    // takes care of the case when the last page has less than pageSize items.
    // It's the same as Math.Ceiling() but using integers.
    int numberOfPages = (aList.Count / pageSize)
        + (aList.Count % pageSize == 0 ? 0 : 1);
    // 0 based
    int currentPage = 0;
    
    IEnumerable<SomeType> itemsOnThisPage = aList.Skip(currentPage * pageSize).Take(pageSize);
