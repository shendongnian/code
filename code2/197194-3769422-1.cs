    XDocument document = XDocument.Parse(xml);
    var query = from customer in document.Root.Elements("Customer")
                group customer by customer.Element("Sex").Value into sexgroup
                select new XElement(sexgroup.Key,
                    from cust in sexgroup
                    select new XElement("Customer",
                        cust.Element("Name"),
                        cust.Element("Age"),
                        cust.Element("Order")));
    XDocument changedOutput = new XDocument();
    changedOutput.Add(new XElement("GroupedCustomers", query));
