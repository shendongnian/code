private List<TicketChartData> GenerateImpl(IList<ServiceItem> myList, string field)
{
    IQueryable<ServiceItem> queryableList = myList.AsQueryable<ServiceItem>();
    IQueryable groupedList = queryableList.GroupBy(field,"it").
                            OrderBy("Key descending").
                            Select("new (Key as Key, Count() as Count)");
       
    // Note: IQueryable doesn't have ToList() implementation - only IEnumerable 
    return output.ToList(); // will not work
}
