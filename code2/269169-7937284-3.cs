            protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var bytes = Context.Cache.Get(Request.QueryString.Get("cacheKey")) as byte[];
                Response.Clear();
                Response.AddHeader(
                    "content-disposition", string.Format("attachment; filename={0}.xlsx", "Invoice"));
                Response.ContentType = "application/xlsx";
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }
