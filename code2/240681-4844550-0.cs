	private double Evaluate(string expression)
        {
            return (double)new System.Xml.XPath.XPathDocument
            (new System.IO.StringReader("<r/>")).CreateNavigator().Evaluate
            (string.Format("number({0})", new
            System.Text.RegularExpressions.Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
            .Replace("/", " div ").Replace("%", " mod ")));
        }
	OR
	private double Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
	public double PerformOperation(double x, double y, string op)
	{
		string exp = x.ToString() + op + y.ToString();
		return Evaluate(exp);
	}
