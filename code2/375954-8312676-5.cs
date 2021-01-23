     protected void Page_Load(object sender, EventArgs e)
        {
            object _return = new
            {
                error = "",
                status = true
            };
            JavaScriptSerializer _serializer = new JavaScriptSerializer();
            if (!Page.IsPostBack)
            {
                string str = Request.QueryString["request"].ToString();
                switch (str.ToLower())
                {
    case "getcities":
                        int countryID = Convert.ToInt32(Request.QueryString["countryID"].ToString());
                        _return = JQueryJson.Core.City.getAllCitiesByCountry(countryID).Select(_city => new
                        {
                            id = _city.ID,
                            title = _city.Name
                        });
                        _serializer = new JavaScriptSerializer();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.ContentType = "text/json";
                        Response.Write(_serializer.Serialize(_return));
                        break;
    }
    // etc........
    }
