    collection = nonLabors.Select(item =>
                    {
                        item.Travel_Miles = item.Travel_Miles_Original != null ? decimal.Parse(item.Travel_Miles_Original) : 0;
                        return item;
                    }).ToList();
