    public class MyUmbracoApplication : Umbraco.Web.UmbracoApplication
    {       
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            base.OnApplicationStarted(sender, e);
            GlobalFilters.Filters.Add(new LanguageFilterAttribute());
        }
        
    }
