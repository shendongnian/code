class child
{
	public string type { get; set; }
	public string name { get; set; }
	public string comparisonOperator { get; set; }
	public string value1 { get; set; }
}
You should be able to instantiate a populated collection like this:
var children = new List<child> {
		new child
		{
		  type = "filter",
		  name = "FISCAL_YEAR",
		  comparisonOperator = "=",
		  value1 = "PROJ_FY_CD"
		},
		new child
		{
			type = "filter",
			name = "PERIOD_NO",
			comparisonOperator = "=",
			value1 = "PROJ_PD_NO"
		},
		new child
		{
			type = "filter",
			name = "SUB_PERIOD_NO",
			comparisonOperator = "=",
			value1 = "PROJ_SUB_PD_NO"
		},
	};
