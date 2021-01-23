            if (!IsPostBack)
            {
                string mName = "testy";
                HtmlHead pHtml = Page.Header;
                foreach (HtmlMeta metaTag in pHtml.Controls.OfType<HtmlMeta>())
                {
                    if (metaTag.Name.Equals(mName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        metaTag.Content = "Yeah!";
                        break; //You could keep looping to find other controls with the same name, but I'm exiting the loop
                    }
                }
                //for (int i = pHtml.Controls.Count - 1; i >= 0; i--)
                //{
                //    if (pHtml.Controls[i] is HtmlMeta)
                //    {
                //        HtmlMeta thisMetaTag = (HtmlMeta)pHtml.Controls[i];
                //        if (thisMetaTag.Name == mName)
                //        {
                //            thisMetaTag.Content = "Yeah!";
                //           // pHtml.Controls.RemoveAt(i);
                //        }
                //    }
                //} 
            }
        }
