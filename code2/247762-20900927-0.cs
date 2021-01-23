    public PagedResult<T> SearchPaged<T>(PagedQuery query)
        {
            try
            {
                //the PagedQuery object is just a holder for a detached criteria and the paging variables
                ICriteria crit = query.Query.GetExecutableCriteria(_session);
                crit.SetMaxResults(query.PageSize);
                crit.SetFirstResult(query.PageSize * (query.Page - 1));
                var data = crit.Future<T>();
                ICriteria countQuery = CriteriaTransformer.TransformToRowCount(crit);
                var rowcount = countQuery.FutureValue<Int32>();
                IList<T> list = new List<T>();
                foreach (T t in data)
                {
                    list.Add(t);
                }
                PagedResult<T> res = new PagedResult<T>();
                res.Page = query.Page;
                res.PageSize = query.PageSize;
                res.TotalRowCount = rowcount.Value;
                res.Result = list;
                return res;
            }
            catch (Exception ex)
            {
                _log.Error("error", ex);
                throw ex;
            }
        }
