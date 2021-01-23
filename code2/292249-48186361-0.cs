            Forms.HtmlElement ddRouteSelected = wBrowser.Document.GetElementById(id);
            foreach (Forms.HtmlElement item in ddRouteSelected.Children)
            {
                if (item.InnerText != null && item.InnerText.ToLower().Equals(value.ToLower()))
                {
                    item.SetAttribute("selected", "Selected");
                    item.SetAttribute("value", value);
                    ddRouteSelected.InvokeMember("onchange");
                    break;
                }
            }
        }
