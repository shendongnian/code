    using (DataClasses1DataContext db = new DataClasses1DataContext("Data Source=localhost\sqlexpress; Initial Catalog=myDBName; Integrated Security=true"))
    {
        IEnumerable<City> citiesForUSA = db.Cities.Where(x => x.Country.Name == "United States");
    
        City city = new City();
        city.Name = "Metropolis";
        //etc
        db.Cities.InsertOnSubmit(city);
        db.SubmitChanges(); // <-- INSERT INTO completed
    
        //etc
    }
