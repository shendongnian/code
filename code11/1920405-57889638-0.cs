            string requestBody = ReadFile("XMLFile1.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(TestRun));
            using (TextReader reader = new StringReader(requestBody))
            {
                //convert the xml to object
                TestRun testRun = (TestRun)serializer.Deserialize(reader);
                foreach (var result in testRun.Results.UnitTestResult)
                {
                    Console.WriteLine($"{result.TestName} : {result.Outcome}");
                }
            }
