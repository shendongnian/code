    var pageNumber = 1;// current page should come from the client
    var filter = new BaseFilter(){CurrentPage = pageNumber, ItemsPerPage = 30};
    var items = GetItemsByFilter(filter, Query.LTE("SomeDate",DateTime.Now)),
                                         SortBy.Ascending("SortField"));
    //For basic paging you only following three properties
    var totalCount = filter.TotalCount; // here will be total items count
    var pagesCount = filter.TotalPagesCount; // here will be total pages count
    // pageNumber  = current page
 
