        var iter = HttpContext.Current.Cache.GetEnumerator();
        using (iter as IDisposable)
        {
            while (iter.MoveNext())
            {
                string s;
                if ((s = iter.Key as string) != null && s.Contains("subcat"))
                {
                    //... let the magic happen
                }
            }
        }
