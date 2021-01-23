    [Serializable]
        public class GroupCountProjection : SimpleProjection
        {
            private PropertyProjection[] _projections;
    
            public GroupCountProjection(PropertyProjection[] projections)
            {
                _projections = projections;
            }
    
            public override bool IsAggregate
            {
                get { return true; }
            }
    
            public override IType[] GetTypes(ICriteria criteria, ICriteriaQuery criteriaQuery)
            {
                return new IType[] { NHibernateUtil.Int32 };
            }
    
            public override SqlString ToSqlString(ICriteria criteria, int position, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
            {
                SqlStringBuilder result = new SqlStringBuilder()
                    .Add(" count(*) as y")
                    .Add(position.ToString())
                    .Add("_ from ( select ");
                for (int index = 0; index < _projections.Length; index++)
                {
                    PropertyProjection projection = _projections[index];
                    if (index > 0)
                        result.Add(",");
                    result.Add(projection.ToSqlString(criteria, ++position, criteriaQuery, enabledFilters));
                }
                result.Add(" ");
                return result.ToSqlString();
            }
    
            public override string ToString()
            {
                return "select count(*)";
            }
    
            public override bool IsGrouped
            {
                get { return true; }
            }
    
            public override SqlString ToGroupSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery,
                                                       IDictionary<string, IFilter> enabledFilters)
            {
                SqlStringBuilder result = new SqlStringBuilder();
                for (int index = 0; index < _projections.Length; index++)
                {
                    PropertyProjection projection = _projections[index];
                    if (index > 0)
                        result.Add(",");
                    result.Add(StringHelper.RemoveAsAliasesFromSql(projection.ToSqlString(criteria, 0, criteriaQuery,enabledFilters)));
                }
                result.Add(") as tbly");
                return result.ToSqlString();
            }
        }
