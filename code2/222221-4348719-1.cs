    MyViewModel vm= new MyViewModel();
    
    using (DealDataContext db = new DealDataContext())
    {
        XElement xmlTree = XElement.Parse("<Request><ZipCode>92618</ZipCode></Request>");
        var result = db.SearchDeals(xmlTree);
    
        vm.filters = result.GetResult<Filter>().ToList();
        vm.deals = result.GetResult<Deal>().ToList();
        return vm;
    
    }
