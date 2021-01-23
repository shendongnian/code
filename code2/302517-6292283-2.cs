    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string id = RouteData.Values["id"].ToString();
            string passedSlug = RouteData.Values["name"].ToString();
            //get the original slug from database / dymanic method
            string originalSlug = GetSlugFromID(id);
    
            if(!originalSlug.Equals(passedSlug))
            {
                var url = String.Format("~/test/{0}/{1}", id, originalSlug);
                Response.RedirectPermanent(url, true);
            }
        }
    }
