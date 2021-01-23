        protected IList<T> GetByCriteria(
            ICriteria criteria, 
            int pageIndex,
            int pageSize, 
            out long totalCount)
        {
            ICriteria recordsCriteria = CriteriaTransformer.Clone(criteria);
            // Paging.
            recordsCriteria.SetFirstResult(pageIndex * pageSize);
            recordsCriteria.SetMaxResults(pageSize);
            // Count criteria.
            ICriteria countCriteria = CriteriaTransformer.TransformToRowCount(criteria);
            // Perform multi criteria to get both results and count in one trip to the database.
            IMultiCriteria multiCriteria = Session.CreateMultiCriteria();
            multiCriteria.Add(recordsCriteria);
            multiCriteria.Add(countCriteria);
            IList multiResult = multiCriteria.List();
            IList untypedRecords = multiResult[0] as IList;
            IList<T> records = new List<T>();
            if (untypedRecords != null)
            {
                foreach (T obj in untypedRecords)
                {
                    records.Add(obj);
                }
            }
            else
            {
                records = new List<T>();
            }
            totalCount = Convert.ToInt64(((IList)multiResult[1])[0]);
            return records;
        }
