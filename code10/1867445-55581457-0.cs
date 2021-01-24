    string url = context.Request.Url.AbsoluteUri; // Henter URL
    string[] separateURL = url.Split('?'); // Splitter URL
    NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString    (separateURL[0]); // Parameterne
    string strCategoryId = queryString[0];  // Index 0 er categoryId
    StringBuilder table = new StringBuilder();
    con.Open();
    SqlCommand cmd = new SqlCommand("uspPasteDataSubCategories", con);
    cmd.CommandType = CommandType.StoredProcedure;
    int categoryId = Int32.Parse(strCategoryId);
    cmd.Parameters.Add("@categoryid", SqlDbType.Int);
    cmd.Parameters["@categoryid"].Value = categoryId;
    SqlDataReader rd = cmd.ExecuteReader();
