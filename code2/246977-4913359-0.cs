    var businesses = doc.Descendants(ns + "businessEntity")
             .Select(businessEntityNode => new
             {
                 LegalName = businessEntityNode.Elements(ns + "legalName")
                     .Select(node => new
                 {
                     EffectiveFrom = node.Element(ns + "effectiveFrom").Value,
                     GivenName = node.Element(ns + "givenName").Value,
                     FamilyName = node.Element(ns + "familyName").Value,
                 }).ToList()
                 // etc...
             }).ToList();
