    using ( DbManager db = new MyDbManager() )
    {
        IQueryable<MyObjects> qObjs = 
            from p in db.GetTable<MyObjects>()
            //sometimes with additional parameters
            select p;
    
        // ... another logic, that could pass qObj into other part of program
    
        IList<MyObjects> objects = qObjs
            .Where(obj=>obj.SomeValue>=SomeLimit)    // here I want to put additional filters
            .ToList()  // and only after that I wan't to execute query and fetch results
            ;
    }
