    public TaxAuditorSettings GetAuditorSettings(ISession session)
    {
        // assuming there is a ctor taking the enumerables as parameter
        return new TaxAuditorSettings(
            session.CreateSQLQuery("SELECT MONTH_NUMBER, YEAR FROM TAX_AUDITOR_ALLOWED_MONTHS")
                .SetResultTransformer(new MonthResultTransformer())
                .Future<Month>(),
            session.CreateCriteria<Company>()
                .Add(NHibernate.Criterion.Expression.Sql("Id IN (SELECT COMPANY_ID FROM TAX_AUDITOR_ALLOWED_COMPANIES)"))
                .Future<Company>())
    }
    class MonthResultTransformer : IResultTransformer
    {
        public IList TransformList(IList collection)
        {
            return collection;
        }
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            return new Month
            {
                MonthNumber = (int)tuple[0],
                Year = (int)tuple[1],
            }
        }
    }
