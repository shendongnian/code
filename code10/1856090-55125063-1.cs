    public async Task<IEnumerable<Animal>> GetAnimalsFromAttributesAsync(DataTable attributeSets)
    {
        using (var myDB = new SqlConnection(connectionString))
        {
            await myDB.OpenAsync();
    
            var sql = @"select AnimalID, AnimalTypeID, AnimalColor
                        from Animals
                        inner join @animalInfos animalInfos on 
                            animalInfos.AnimalColorID = Animals.ColorID 
                                and 
                            animalInfos.AnimalTypeID = Animals.AnimalTypeID";
    
            var result = myDB.QueryAsync<Animal>(sql, new { animalInfos = attributeSets.AsTableValuedParameter("AnimalInfo") };
    
            return result;
        }
    }
