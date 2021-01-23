            var list = new List<ISearchItem>();
            foreach (T item in instances)
            {
                try
                {
                    var type = typeof(T);
                    var inter = item.GetType().GetInterface(type.Name);
                    var results = (ISearchItem[])inter.InvokeMember("Search", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public, null, item, new object[] { searchValue });
                    if(results != null)
                        list.AddRange(results);
                }
                catch (System.Exception) { }
            }
