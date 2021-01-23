    string searchText = Request.QueryString["search"].Trim();
    string encodedValue = Server.HtmlEncode(searchText);
    string escapedValue = Regex.Escape(encodedValue);
    string contentText = Content.Text;
    contentText = Regex.Replace(contentText, @"(?s)<.*?>", string.Empty);
    contentText = Regex.Replace(contentText, escapedValue, 
        "<font class='highlight2'>$&</font>", RegexOptions.IgnoreCase);
    Content.Text = contentText;
