            public List<Vulner> VulnerSelect(int[] idList = null, string[] navigationPropertiesList = null)
        {
            var query = from vulner in _businessModel.DataModel.VulnerSet
                        select vulner;
            if (navigationPropertiesList != null)
                navigationPropertiesList.Select(p =>{query = ((ObjectQuery<Vulner>)query).Include(p);
                                       return true; });
            if (idList != null)
                query = query.Where(p => idList.Contains(p.Id));
            return query.ToList();
        }
