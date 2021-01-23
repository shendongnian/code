    var businesses = (
        from node in doc.Descendants(ns + "businessEntity")
        let legalName = node.Element(ns + "legalName")
        let abn = node.Element(ns + "ABN")
        // etc...
        select new
        {
            LegalName = new
            {
                EffectiveFrom = legalName.Element(ns + "effectiveFrom").Value,
                GivenName = legalName.Element(ns + "givenName").Value,
                FamilyName = legalName.Element(ns + "familyName").Value,
            },
            Abn = new
            {
                IdentifierValue = abn.Element(ns + "identifierValue").Value,
                IsCurrentIndicator = abn.Element(ns + "isCurrentIndicator").Value,
                ReplacedFrom = abn.Element(ns + "replacedFrom").Value,
            }
            // etc...
        }).ToList();
 
    Console.WriteLine(businesses[0].LegalName.GivenName);
    Console.WriteLine(businesses[0].Abn.IsCurrentIndicator);
