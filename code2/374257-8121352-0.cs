    foreach (XPathNavigator val in it)
    {
        testData = new TestData();
        testData.TestPosition = pos;
        testData.TestName = val.SelectSingleNode(nav.Compile("Name")).Value;
        testData.TestValue = val.SelectSingleNode(nav.Compile("Value")).Value;
        Datas.Add(testData);
        pos++;
    }
