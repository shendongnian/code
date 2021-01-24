    var xml = @"<Table>
                  <ID>1</ID>
                  <Name>John</Name>
                  <Age>25</Age>
               </Table>"; // replace this by webservice response 
            XDocument xmldoc = XDocument.Parse(xml);
            var employee = xmldoc.Descendants("Table").Select(x => new
            {
                ID = x.Element("ID").Value,
                Name = x.Element("Name").Value,
                Age = x.Element("Age").Value,
            }).FirstOrDefault();
            Console.WriteLine(employee.Name);
