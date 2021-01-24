    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    namespace CompanyName.UnitTests
    {
        [TestClass]
        public class EntityFreameworkDbTests
        {
            public TestContext TestContext { get; set; }
    
            [TestMethod]
            public void VerifyEdmxConcurrencyColumns()
            {
                const int minExpectedEdmxPathCount = 65;
    
                // Expected Output:  List all columns in all edmx that set ConcurrencyMode = fixed
                //
                List<Tuple<string, string, string>> expected = new List<Tuple<string, string, string>>
                {
                    // EMDX, TableName, ColumnName
                    Tuple.Create("TheFileName.edmx", "ActivityLog", "Successes"),
                    Tuple.Create("TheFileName.edmx", "ActivityLog", "Fails")
                };
    
                // use top of source tree to include all edmx files
                string serverSourceDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    
                string [] edmxPaths = Directory.GetFiles(serverSourceDir, "*.edmx", SearchOption.AllDirectories);
    
                Assert.IsTrue(edmxPaths.Count() >= minExpectedEdmxPathCount, "Under the expected min count of edmx paths: Actual = {0}, Expected = {1}"
                    .FormatExt(edmxPaths.Count(), minExpectedEdmxPathCount));
    
                List<Tuple<string, string, string>> actual = new List<Tuple<string, string, string>>();
    
                TestContext.WriteLine("All Actuals:");
    
                foreach (string edmxPath in edmxPaths)
                {
                    XDocument xmlDoc = XDocument.Load(edmxPath);
    
                    IEnumerable<XElement> concurrencyFixedColumns = xmlDoc.Descendants()
                        .Where(el => (string)el.Attribute("ConcurrencyMode") == "Fixed");
    
                    foreach (XElement el in concurrencyFixedColumns)
                    {
                        string value = el.Attribute("ConcurrencyMode")?.Value;                   //modified = true;
    
                        if (value != null)
                        {
                            string edmxFile = Path.GetFileName(edmxPath);
                            string tableName = (string)el.Parent.Attribute("Name"); 
                            
                            actual.Add(Tuple.Create(edmxFile, tableName, (string)el.Attribute("Name")));
                            TestContext.WriteLine("\t{0},{1},{2}", edmxFile, tableName, el.Attribute("Name"));
                        }
                    }
                }
    
                StringBuilder errors = new StringBuilder();
    
                actual.Except(expected).ToList().ForEach(edmxColumn =>
                    errors.AppendLine("Actual but not expected: " + edmxColumn.Item1 + "," + edmxColumn.Item2 + "," + edmxColumn.Item3));
    
                expected.Except(actual).ToList().ForEach(edmxColumn =>
                    errors.AppendLine("Expected but not actual: " + edmxColumn.Item1 + "," + edmxColumn.Item2 + "," + edmxColumn.Item3));
    
                Assert.AreEqual(0, errors.Length, "\n\nEF Concurrency=fixed columns:\n" + errors.ToString() + "\n");
            }
        }
    }
