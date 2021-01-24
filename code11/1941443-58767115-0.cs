    for (int index = 0; index < cookies.Count; index++)
    {
        writer.Write("<li>{0:D}> <b>", index);
        HttpUtility.HtmlEncode(cookies.GetKey(index), writer);
        writer.Write("</b> = &quot;");
        HttpUtility.HtmlEncode(cookies[index].Value, writer);
        writer.Write("&quot;</li>");
    }
    // -> cookieExample1=1 cookieExaMPLE1=2
