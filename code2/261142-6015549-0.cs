    public static void LimitCriteriaByPrimaryKeys(this NHibernate.ICriteria criteria, string primaryKeyName, int pageNum, int pageSize)
        {
            var session = NHManager.Instance.GetCurrentSessionFromContext();
            if (pageSize <= 0) pageSize = Int32.MaxValue - 1;
            var nhSession = NHManager.Instance.GetCurrentSessionFromContext();
            var pagingCriteria = (ICriteria)criteria.Clone();
            IList ids = null;
            var pKeyIDName = Projections.Property(primaryKeyName);  
            var pKeyProjection = Projections.Distinct(pKeyIDName); 
            {
                {
                    //paging
                    pagingCriteria.SetProjection(pKeyProjection); //sets the primary key distinct projection
                    if (pageSize > 0)
                    {
                        if (pageNum < 1)
                            pageNum = 1;
                        int skipAmt = (pageNum - 1) * pageSize;
                        pagingCriteria.SetFirstResult(skipAmt);
                        pagingCriteria.SetMaxResults(pageSize); 
                        ids = pagingCriteria.List(); //this returns the distinct list of IDs which should be returned for the given page & size
                    }
                }
            }
            {
                if (ids != null && ids.Count > 0)
                {
                    criteria.Add(Expression.In(pKeyIDName, ids));   //adds the primary key restriction
                    var crit = criteria;
                    crit.SetResultTransformer(new NHibernate.Transform.DistinctRootEntityResultTransformer());
                }
                else
                {
                    criteria.Add(Expression.Eq(pKeyIDName, 0)); //this is added specifically so that the main criteria returns NO results
                    criteria.Add(Expression.Eq(pKeyIDName, 1));
                }
            }
        }
