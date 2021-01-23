    foreach (SyndicationItem item in feed.Items)
    {
       int s,f;
            s = item.Summary.Text.IndexOf("<");
            f = item.Summary.Text.IndexOf("/>");
            if (f != -1)
                div1.InnerHtml += "</br>photo:" + item.Summary.Text.Substring(s, f + 1 - s);
    }
