    public List<Owner> Get()
    {
        var ownerWithCars  = (from o in db.Owners 
                             join c in db.Cars on o.Id equals c.OwnerId
                             select o).Distinct().ToList();
                   
        return ownerWithCars ;
    }
