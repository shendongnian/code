    IEnumerable<Customer> query = customerSearchDataModels;
    if(UseContainsName)
        query = query 
            .Where(x => x.Number.Contains(NameNumberEntryText));
    if(UseContainsPhone)
        query = query 
            .Where(x => x.PrimaryPhone.Contains(PhoneEntryText));
    var result = query.ToList();
