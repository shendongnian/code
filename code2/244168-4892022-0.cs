    // Encode the string input
    StringBuilder sb = new StringBuilder(
                            HttpUtility.HtmlEncode(htmlInputTxt.Text));
    // Selectively allow <b> and <i>
    sb.Replace("&lt;b&gt;", "<b>");
    sb.Replace("&lt;/b&gt;", "");
    sb.Replace("&lt;i&gt;", "<i>");
    sb.Replace("&lt;/i&gt;", "");
    Response.Write(sb.ToString());
