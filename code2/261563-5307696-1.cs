            var Tests = from tests in doc.Descendants("Test")
                        where tests.Attributes().Count() > 0
                        select new LabTestModel
                                    {
                                        LabName = tests.Parent.Attribute("Name").Value,
                                        TestName = tests.Attribute("Name").Value
                                    };
