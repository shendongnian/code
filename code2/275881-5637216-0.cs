    var itemsToFilter = ss.ToList();
    string str = FilterAllSource;
                if (!string.IsNullOrEmpty(str))
                {
                    itemsToFilter = itemsToFilter.Where(it => (it.SourceCode.ToUpper()
                                               .Contains(str.ToUpper())
                                         || it.SourceName.ToUpper()
                                               .Contains(str.ToUpper())));
                }
                if (top > 0)
                    itemsToFilter = itemsToFilter.Take(top);
                return itemsToFilter.ToList();
