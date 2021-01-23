        private static string UrlForTab(IAccessible tab)
        {
            try
            {
                var desc = tab.get_accDescription(0);
                if (desc != null)
                {
                    if (desc.Contains("\n"))
                    {
                        string url = desc.Substring(desc.IndexOf("\n")).Trim();
                        return url;
                    }
                    else
                    {
                        return desc;
                    }
                }
            }
            catch { }
            return "??";
        }
