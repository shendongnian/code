        QueryExpression query = new QueryExpression
        {
            EntityName = "new_involvedperson",
            //columns to be included in query
            ColumnSet = new ColumnSet(true),
            Criteria = new FilterExpression(LogicalOperator.And)
            {
                Conditions =
                {
                    new ConditionExpression("new_personid", ConditionOperator.Equal, "{70B1E0F8-9205-E111-9C76-005056A44AF5}"),
                    new ConditionExpression("new_roletype", ConditionOperator.Equal, 1),
                }
            },
            LinkEntities =
            {
                new LinkEntity()
                {
                    LinkFromAttributeName = "new_personid",
                    LinkToEntityName = "new_person",
                    LinkToAttributeName = "new_personnameid",
                }
            }
        };
