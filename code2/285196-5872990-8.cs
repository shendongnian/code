    IEnumerable<Car> fst=allListsOfCars.FirstOrDefault();
    if(result!=null)
    {
        HashSet<Car> hs=new HashSet<Car>(fst);
        foreach(var sublist in allListsOfCars.Skip(1))
        {
            hs.IntersectWith(sublist); //in-place operation
        }
        //enumerate hs
    }
