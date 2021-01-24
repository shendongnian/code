    List<Issue> list = (from i in (IQueryable<Issue>)jira.Issues.Queryable
                                        where i.Project == ProcessConfiguration.ParentProjectKey
                                        && (DateTime)i.Created >= (DateTime)jiraSelectInputDto[0].FromDate
                                        && (DateTime)i.Created <= (DateTime)jiraSelectInputDto[0].ToDate
                                        && i["Customer"] == new LiteralMatch(cusProvince.Province)
                                        orderby i.Key descending
                                        select i).ToList();
