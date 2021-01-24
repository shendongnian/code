    var orgs = JObject.Parse(json);
    var orgsStartingWithA = 
        orgs.DescendantsAndSelf()
            .OfType<JObject>()
            .Where(t => t["orgname"] != null && t["orgname"].Value<string>().StartsWith("Org A"))
            .ToList();
    foreach (var org in orgsStartingWithA)
    {
        Console.WriteLine(org["orgname"]);
    }
