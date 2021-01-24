    public void CombineTenatsAndPets()
    {
        //Create data
        var tenants = Enumerable.Range(0, 10).Select(_ => new Tenant()
        {
            PetList = Enumerable.Range(0, 5).Select(_ => new Pet()).ToList()
        });
        var tenantsAndPets = tenants
            .SelectMany(t =>
                t.PetList.Select(p => new KeyValuePair<string, Pet>(
                        $"{t.BuildingNumber}-{t.Name}-{p.Age}", p)))
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
