    var parameters = HttpUtility.ParseQueryString(string.Empty);
    parameters["q"] = ListBox1.SelectedValue;
    parameters["cr"] = ListBox3.SelectedValue;
    parameters["p"] = ListBox1.SelectedValue;
    var url = string.Format("~/WebPage2.aspx?{0}", parameters.ToString());
    Response.Redirect(url);
