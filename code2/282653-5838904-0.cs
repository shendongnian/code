            string cssColorbox = Page.ClientScript.GetWebResourceUrl(this.GetType(),
                "MyNamespace.Styles.colorbox.css");
            string cssPagination = Page.ClientScript.GetWebResourceUrl(this.GetType(),
              "MyNamespace.Styles.pagination.css");
            HtmlGenericControl colorboxCss = new HtmlGenericControl("link");
            colorboxCss.Attributes.Add("href", cssColorbox);
            colorboxCss.Attributes.Add("type", "text/css");
            colorboxCss.Attributes.Add("rel", "stylesheet");
            HtmlGenericControl paginationCss = new HtmlGenericControl("link");
            paginationCss.Attributes.Add("href", cssPagination);
            paginationCss.Attributes.Add("type", "text/css");
            paginationCss.Attributes.Add("rel", "stylesheet");
            Page.Header.Controls.Add(colorboxCss);
            Page.Header.Controls.Add(paginationCss);
