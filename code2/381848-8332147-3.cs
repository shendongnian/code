    [TestMethod]
    public void MyTestMethod()
    {
        Class1 target = new Class1();
        List<string> results = new List<string>();
        for (int i = 0; i < 100000; i++)
        {            
            string result = target.UniqueString();
            if (!results.Contains(result))
                results.Add(result);
            else
                Assert.Fail(string.Format("The string '{0}' is already in the list", result));
        }
       Console.WriteLine(results.Count.ToString());
    }
