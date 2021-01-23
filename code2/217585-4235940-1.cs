    var businesses = new List<Business>();
    var lines = File.ReadLines(path);
    foreach(var line in lines) {
        string[] fields = line.Split(',');
        string companyName = fields[0];
        string addressLine = fields[1];
        Business business = new Business(companyName, addressLine);
        businesses.Add(business);
    }
    
