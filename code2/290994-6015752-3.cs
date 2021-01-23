     var customer = from c in XDocument.Load("XMLPATH").Descendants("Customer")
                               where (string)c.Attribute("Name")=="Jason Voorhees"
                               select new Customer
                               {
                                   Name=(string)c.Attribute("Name"),
                                   WeaponPurchased = (string)c.Attribute("WeaponPurchased"),
                                   SalePrice = (string)c.Attribute("SalePrice"),
    
                               };
    
                foreach (var item in customer)
                {
                    Console.WriteLine(item.WeaponPurchased);
                    
                }
