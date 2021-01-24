    QueryExpression qe = new QueryExpression();
    qe.EntityName = "new_particpiant";
    
    ColumnSet columns = new ColumnSet(
    new string[1]
    {
    	"new_average",
    });
    
    ConditionExpression ce = new ConditionExpression
    {
    	AttributeName = "new_particpiant",
    	Operator = ConditionOperator.Equal,
    	Values = { 'Your Guid' }
    };
    
    FilterExpression filterQuery = new FilterExpression();
    filterQuery.FilterOperator = LogicalOperator.And;
    filterQuery.AddCondition(ce);
    					
    qe.ColumnSet = columns;
    
    EntityCollection ec = service.RetrieveMultiple(qe);
    
    Entity data = new Entity();
    
    if (ec.Entities.Count > 0)
    {
    	data = ec.Entities[0];
    	string average = Convert.ToString(data.Attributes["new_average"]);
    }
