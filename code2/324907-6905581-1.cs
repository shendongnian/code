	[TestMethod]
	public void TestQueryingByCombiningTwoExpressions()
	{
		Expression<Func<MyEntity, string>> fieldExpression = e => e.MyProperty;
		Expression<Func<string, bool>> operatorExpression = o => o.Contains("irs");
		var builder = new ExpressionBuilder<MyEntity>();
		Expression<Func<MyEntity, bool>> combinedExpression = builder.Build(fieldExpression, operatorExpression);
		Assert.AreEqual(1, entities.Where(combinedExpression).Count());
		Assert.AreEqual("e => e.MyProperty.Contains(\"irs\")", combinedExpression.ToString());
	}
