    var filter = new BaseFilter(){CurrentPage = 1, ItemsPerPage = 30};
    var items = GetItemsByFilter(filter, Query.LTE("SomeDate",DateTime.Now)),
                                         SortBy.Ascending("SortField"));
    //For basic paging you only following three properties
    var totalCount = filter.TotalCount; // here will be total items count
    var pagesCount = filter.TotalPagesCount; // here will be total pages count
    var currentPage = filter.CurrentPage; // current page
 
