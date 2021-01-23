    using System.Collections.Generic;
    using System.IO;
    using LumenWorks.Framework.IO.Csv;
    using NUnit.Framework;
    
    namespace mytests
    {
        class MegaTests
        {
            [Test, TestCaseSource("GetTestData")]
            public void MyExample_Test(int data1, int data2, int expectedOutput)
            {
                var methodOutput = MethodUnderTest(data2, data1);
                Assert.AreEqual(expectedOutput, methodOutput, string.Format("Method failed for data1: {0}, data2: {1}", data1, data2));
            }
    
            private int MethodUnderTest(int data2, int data1)
            {
                return 42; //todo: real implementation
            }
    
            private IEnumerable<int[]> GetTestData()
            {
                using (var csv = new CsvReader(new StreamReader("test-data.csv"), true))
                {
                    while (csv.ReadNextRecord())
                    {
                        int data1 = int.Parse(csv[0]);
                        int data2 = int.Parse(csv[1]);
                        int expectedOutput = int.Parse(csv[2]);
                        yield return new[] { data1, data2, expectedOutput };
                    }
                }
            }
        }
    }
