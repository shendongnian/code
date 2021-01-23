    var businesses = (
        from node in doc.Descendants(ns + "businessEntity")
        let legalName = node.Element(ns + "legalName")
        let abn = node.Element(ns + "ABN")
        // etc...
        select new
        {
            LegalName = new
            {
                EffectiveFrom = (string)legalName.Element(ns + "effectiveFrom"),
                GivenName = (string)legalName.Element(ns + "givenName"),
                FamilyName = (string)legalName.Element(ns + "familyName"),
            },
            Abn = new
            {
                IdentifierValue = (string)abn.Element(ns + "identifierValue"),
                IsCurrentIndicator = (string)abn.Element(ns + "isCurrentIndicator"),
                ReplacedFrom = (string)abn.Element(ns + "replacedFrom"),
            },
            // etc...
        }).ToList();
 
    Console.WriteLine(businesses[0].LegalName.GivenName);
    Console.WriteLine(businesses[0].Abn.IsCurrentIndicator);
