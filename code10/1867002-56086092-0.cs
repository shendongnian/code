    public void ReadResultsXmlFile(string testResultsXmlFile)
    {
        using (MyXmlTextReader = new XmlTextReader(testResultsXmlFile))
        {
            testResultXmlDocument = new XmlDocument();
            testResultXmlDocument.Load(MyXmlTextReader); // suppose that myXmlString contains "<Names>...</Names>"
            XmlNode xnAssembliesHeader = testResultXmlDocument.SelectSingleNode("/assemblies");
            TestRunDateTime = xnAssembliesHeader.Attributes.GetNamedItem("timestamp").Value;
            XmlNodeList xnAssemblyList = testResultXmlDocument.SelectNodes("/assemblies/assembly");
            foreach (XmlNode assembly in xnAssemblyList)
            {
                XmlNodeList xnTestList = testResultXmlDocument.SelectNodes(
                    "/assemblies/assembly/collection/test");
                foreach (XmlNode test in xnTestList)
                {
                    TestName = test.Attributes.GetNamedItem("name").Value;
                    TestDuration = test.Attributes.GetNamedItem("time").Value;
                    PassOrFail = test.Attributes.GetNamedItem("result").Value;
                    // Failed test, get the failure information
                    if (!(PassOrFail == "Pass"))
                    {
                        Passed = false;
                        XmlNode failureData = test.SelectSingleNode("failure");
                        FailureText = failureData.InnerText;
                        StackTrace = failureData.SelectSingleNode("stack-trace").InnerText;
                        FailureMessage = failureData.SelectSingleNode("message").InnerText;
                        Console.WriteLine("Test: {0} Result: {1}  Error: {2}  StackTrace: {3}", TestName, PassOrFail, FailureMessage, FailureStackTrace);
                    }
                    else
                    {
                        Passed = true;
                    }
                    Console.WriteLine("Test: {0} Result: {1}  Elapsed: {2}", TestName, PassOrFail, TestDuration);
                }
            }
        }
    }
