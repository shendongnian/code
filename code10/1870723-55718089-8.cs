    [TestMethod]
    public void TestMethod1() {
        var data = new List<DataSet>
        {
            new DataSet() { A = 1, B = "One", C = 1.1 },
            new DataSet() { A = 2, B = "Two", C = 2.2 },
            new DataSet() { A = 3, B = "Three", C = 3.3 }
        };
        var propertyKnownAtRuntime = "A";
        var expression = GetPropertyExpression<DataSet>(propertyKnownAtRuntime);
        var listA = data.Select(expression.Compile()).ToList();
        //Produces
        // { 1, 2, 3}
        var listAC = SelectDynamicData(data, new List<string> { "A", "C" });
        //Produces
        //{
        //  { 1, 2, 3},
        //  { 1.1, 2.2, 3.3 }
        //}                
    }
