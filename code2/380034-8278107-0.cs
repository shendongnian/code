            foreach (HtmlElement item in webBrowser1.Document.All)
            {
                if ( item.OuterHtml != null)
                {
                    if (item.OuterHtml.Contains("submitEdgeStory"))
                    {
                        item.InvokeMember("click");
                        break;
                    }
                }
            }
