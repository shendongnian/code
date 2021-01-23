	XElement req = 
        new XElement("order",
            new XElement("client", 
                new XAttribute("id",clientId),
                new XElement("quoteback", new XAttribute ("name",quotebackname))  
                ),
            new XElement("accounting",
                new XElement("account"),
                new XElement("special_billing_id")
                ),
                new XElement("products", 
                    new XElement(productChoices.Single(pc => pc.ChoiceType == choiceType).Name, 
                        from p in products
                        where p.ChoiceType == choiceType
                        select new XElement(p.Name)
                  )
              )
          );
