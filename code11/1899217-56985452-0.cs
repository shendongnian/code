public MapMode CurrentMapMode
{
    get
    {
        if (!(CurrentPage is EstateDisplayPage))
            return MapService.GetMapMode(Request.QueryString, CurrentPage as ISiteWithMap);
                
        var page = CurrentPage as EstateDisplayPage;
        foreach (var item in page.ContentArea.Items)
        {
            var block = ServiceLocator.Current.GetInstance<IContentLoader>()
            .Get<IContent>(item.GetContent().ContentLink);
            if (block is ISiteWithMap)
            {
                return MapService.GetMapMode(Request.QueryString, block as ISiteWithMap);
            }
        }
        return MapMode.Google;
    }
}
