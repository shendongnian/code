            {
                List<DataItem> _data = CreateData();        
        
                if (!string.IsNullOrEmpty(searchLOGIN_ID))
                {
                    _data = _data.Where(x => x.LOGIN_ID.ToUpper().Contains(searchLOGIN_ID.ToUpper()).ToList();
                }
        
                if (!string.IsNullOrEmpty(searchNAME))
                {
                  _data = _data.Where(x => x.NAME.ToUpper().Contains(searchNAME.ToUpper()).ToList();            
                }
        
                if (!string.IsNullOrEmpty(searchDT_EDIT))
                {
                 _data = _data.Where(x => x.DT_EDIT.ToUpper().Contains(searchDT_EDIT.ToUpper()).ToList();
                }
                
                if (!string.IsNullOrEmpty(search))
                {
                 _data = _data.Where(x => x.LOGIN_ID.ToUpper().Contains(search.ToUpper()) ||
                            x.NAME.ToString().Contains(search.ToUpper()) ||
                            x.DT_EDIT.ToString().Contains(search.ToUpper()).ToList();            
                }
                 list = _data;
        
                // past this point this is your original code :)
                // simulate sort
                //=== sortColumn need to change additional column
                if (sortColumn == 1)
                {   // sort LOGIN_ID
                    list.Sort((x, y) => SortString(x.LOGIN_ID, y.LOGIN_ID, sortDirection));
                }
                else if (sortColumn == 2)
                {   // sort NAME
                    list.Sort((x, y) => SortString(x.NAME, y.NAME, sortDirection));
                }
                else if (sortColumn == 3)
                {   // sort DT_CREATE
                    list.Sort((x, y) => SortDateTime(x.DT_EDIT, y.DT_EDIT, sortDirection));
                }
        
                recordFiltered = list.Count;
        
                // get just one page of data
                list = list.GetRange(start, Math.Min(length, list.Count - start));
        
                return list;
            }
