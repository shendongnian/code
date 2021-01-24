            var teamPrincipalTypeCode = 9;
            var query = new QueryExpression("task");
            var principalObjectAccess = query.AddLink("principalobjectaccess", "activityid", "objectid");
            principalObjectAccess.LinkCriteria.AddCondition("principaltypecode", ConditionOperator.Equal, teamPrincipalTypeCode);
            var entityCollection = _service.RetrieveMultiple(query);
