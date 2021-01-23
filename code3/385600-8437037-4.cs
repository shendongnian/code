        protected override void OnPreRender(EventArgs e)
        {
            if (!IsPostBack)
            {
                string mName = "testy";
                HtmlHead pHtml = Page.Header;
                foreach (HtmlMeta metaTag in pHtml.Controls.OfType<HtmlMeta>())
                {
                    if (metaTag.Name.Equals(mName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        metaTag.Content = "Yeah!";
                        break;
                    }
                }
            }
            base.OnPreRender(e);
        }
