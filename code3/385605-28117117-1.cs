        public class WebUtils
    {
        public static void SetPageMeta(string metaName, string metaContent, HttpContext httpContext = null)
        {
            if (string.IsNullOrWhiteSpace(metaName))
                return;
            if (metaContent == null)
                throw new Exception("Dynamic Meta tag content can not be null. Pl pass a valid meta tag content");
            if (httpContext == null)
                httpContext = HttpContext.Current;
            Page page = httpContext.Handler as Page;
            if (page != null)
            {
                HtmlMeta htmlMetaCtrl = (from ctrls in page.Header.Controls.OfType<HtmlMeta>()
                                         where ctrls.Name.Equals(metaName, StringComparison.CurrentCultureIgnoreCase)
                                         select ctrls).FirstOrDefault();
                if (htmlMetaCtrl != null)
                    page.Header.Controls.Remove(htmlMetaCtrl);
                htmlMetaCtrl = new HtmlMeta();
                htmlMetaCtrl.HttpEquiv = metaName;
                htmlMetaCtrl.Name = metaName;
                htmlMetaCtrl.Content = metaContent;
                page.Header.Controls.Add(htmlMetaCtrl);
            }
            else
            {
                throw new Exception("Web page handler context could not be obtained");
            }
        }
    }
