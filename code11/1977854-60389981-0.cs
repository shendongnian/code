    public static void main()
    {
    	string NestedQuery = "";
    	int NestedQueryCounter = 0;
    	string query = "<View><Query><Where>";
    	var whereClauses = new List<string>();
    	whereClauses.Add(SetupQueryExpression("FirstFiled", FirstValue, "Text", "Eq"));
    	whereClauses.Add(SetupQueryExpression("SecondFiled",SecondValue, "Text", "Contains"));
    	whereClauses.Add(SetupQueryExpression("ThirdField", ThirdValue, "Text", "Contains"));
    	whereClauses.Add(SetupQueryExpression("ForthField", ForthValue, "DateTime", "Eq", "IncludeTimeValue='false'"));
    	whereClauses.Add(SetupQueryExpression("FifthField",FifthValue, "DateTime", "Eq", "IncludeTimeValue='false'"));
    	NestedWhereClauses(whereClauses, "<And>", "</And>");
    	query += NestedQuery;
    	query += "</Where></Query></View>";	
    }
    
    private string SetupQueryExpression(string fieldName, string fieldValue, string dataType, string condition, 
                string extraValueCondition = "")
    {
    	string query = @"<{0}>
    						 <FieldRef Name='{1}' /><Value Type='{2}' {4}>{3}</Value>
    					 </{0}>";
    	return string.Format(query, condition, fieldName, dataType, fieldValue, extraValueCondition);
    }
    
    private void NestedWhereClauses(List<string> whereCalauses, string mainCondition, string endMainCondition)
    {
    	if (2 == whereCalauses.Count)
    	{
    		NestedQuery += mainCondition;
    		NestedQuery += whereCalauses[0];
    		NestedQuery += whereCalauses[1];
    		NestedQuery += endMainCondition;
    		for (int counter = 0; counter < NestedQueryCounter; counter++)
    			NestedQuery += endMainCondition;
    	}
    	else
    	{
    		NestedQueryCounter++;
    		NestedQuery += mainCondition;
    		NestedQuery += whereCalauses[0];
    		whereCalauses.RemoveAt(0);
    		NestedWhereClauses(whereCalauses, mainCondition, endMainCondition);
    	}
    }
