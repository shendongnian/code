    string a = "OU=QALevel1,DC=CopTest,DC=copiun2,DC=com";
    // Separate to parts
    string[] parts = a.Split(',');
    // Select the relevant parts
    IEnumerable<string> dcs = parts.Where(part => part.StartsWith("DC="));
    // Join them again
    string result = string.Join(",", dcs);
