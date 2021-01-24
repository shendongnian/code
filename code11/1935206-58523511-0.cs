    static public int GetDomainRoId1(string domainName)
        {
            string hql = "select domain.:param1 from DOMAIN domain where :param2=:param3";
            using (NHibernate.ISession session = NHibernate.NHibernateHelper.GetCurrentSession())
            {
                NHibernate.IQuery query = session.CreateQuery(hql)
                    .SetParameter("param1", DOM_RO_ID)
                    .SetParameter("param2", DOM_DOM_NM)
                    .SetString("param3", domainName)
                    //.ExecuteUpdate();
                IList<int> ids = query.List<int>();
                if (ids.Count == 1)
                {
                    return ids[0];
                }
            }
            return 0;
        }
