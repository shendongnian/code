    public class ViewedContentIndex :
        AbstractIndexCreationTask<ViewedContent, ViewedContentResult>
    {
    public ViewedContentIndex()
    {
        Map = docs => from doc in docs
                      select new
                                 {
                                     doc.ProductId,
                                     Day = doc.DateViewed.Day,
                                     Month = doc.DateViewed.Month,
                                     Year = doc.DateViewed.Year
                                     Count = 1
                                 };
        Reduce = results => from result in results
                            group result by new {
                                 doc.ProductId,
                                 doc.DateViewed.Day,
                                 doc.DateViewed.Month,
                                 doc.DateViewed.Year
                            }
                            into agg
                            select new
                                       {
                                           ProductId = agg.Key.ProductId,
                                           Day = agg.Key.Day,
                                           Month = agg.Key.Month,
                                           Year = agg.Key.Year  
                                           Count = agg.Sum(x => x.Count)
                                       };
    }
