    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    	{
    		ObjectDataSource1.SelectMethod = "<YourSelectMethod>";
    		e.InputParameters.Clear(); // this is a different method with new parameters.
    		e.InputParameters.Add("Param1", "Value1");
    		e.InputParameters.Add("Param2", "Value2");
    		e.InputParameters.Add("Param3", "Value3");
    	}
 
