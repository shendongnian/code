         protected override void Render(HtmlTextWriter writer)
        {///Articles/How-to-disable-or-remove-ViewState-Hidden-Field-in-ASP.Net-Page.aspx
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter ht = new HtmlTextWriter(sw);
            base.Render(ht);
            string html = sb.ToString();
            //The remove the value and it id from the view status this next line
            html = Regex.Replace(html, "<input[^>]*id=\"(__VIEWSTATE)\"[^>]*>", "<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"\"/>", RegexOptions.IgnoreCase);
            //To completely remove the view state use the line below
           // html = Regex.Replace(html, "<input[^>]*id=\"(__VIEWSTATE)\"[^>]*>", "", RegexOptions.IgnoreCase);
            writer.Write(html);
            sb = null; html = null; ht.Dispose(); sw.Dispose();
        }
    
