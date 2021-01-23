    using(AdventureWorksDB aw = new 
    AdventureWorksDB(Settings.Default.AdventureWorks)) {
        var newSalesPeople = from p in aw.SalesPeople
                             where p.HireDate > hireDate
                             orderby p.HireDate, p.FirstName
                             select new { Name = p.FirstName + " " + p.LastName,
                                          HireDate = p.HireDate };
    
        foreach(SalesPerson p in newSalesPeople) {
            Console.WriteLine("{0}\t{1}", p.FirstName, p.LastName);
        }
    }
