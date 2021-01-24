    public class AlertController : UmbracoApiController
    {
        public List<string> GetAllUrls()
        {
            var list = new List<string>();
    
            var allContent = Umbraco.TypedContentAtRoot().FirstOrDefault().DescendantsOrSelf();
            foreach (var page in allContent)
            {
                list.Add(page.Url);
            }
            return list;
        }
    }
