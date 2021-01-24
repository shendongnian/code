    private bool mf_UserFilter(object item)
            {
                string s = md_FilterString;
                if (String.IsNullOrWhiteSpace(s))
                    return true;
                else
                {
                    var srcT = item.GetType();
                    foreach (var f in srcT.GetFields())
                    {
                        string str = f.GetValue(item) as string;
                        if (String.IsNullOrWhiteSpace(str)) continue;
                        bool b = str.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0;
                        if (b) return true;
                    }
                    foreach (var f in srcT.GetProperties())
                    {
                        string str = f.GetValue(item, null) as string;
                        if (String.IsNullOrWhiteSpace(str)) continue;
                        bool b = str.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0;
                        if (b) return true;
                    }
    
                    return false;
                }
            }
