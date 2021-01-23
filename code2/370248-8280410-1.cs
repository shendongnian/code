        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (key.ToString() == "_scripts_")
                {
                    Dictionary<int, List<string>> scripts = htmlHelper.ViewContext.HttpContext.Items[key] as Dictionary<int, List<string>>;
                    foreach (int index in scripts.Keys.OrderBy(x => x))
                    {
                        foreach (string script in scripts[index])
                        {
                            if (script != null)
                            {
                                sb.AppendLine(script);
                            }
                        }
                    }
                }
            }
            return MvcHtmlString.Create(sb.ToString());
        }
