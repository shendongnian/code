    internal static class IssuesConversionsFilter
    {
        public static IOrderedQueryable<Issue> Convert(IQueryable<Issue> query, IssuesSortBy sortBy)
        {
            switch (sortBy)
            {
                case IssuesSortBy.Date: 
                    return query.OrderByDescending(i => i.CreatedDate);
                case IssuesSortBy.Priority:
                    return query.OrderByDescending(i => i.Priority);
                case IssuesSortBy.Type:
                    return query.OrderByDescending(i => i.Type);
                case IssuesSortBy.State:
                    return query.OrderByDescending(i => i.State);
                default:
                    throw new ArgumentOutOfRangeException("sortBy");
            }
        }
    }
