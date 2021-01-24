    [HttpPut]
    [Route("api/city/{Id}")]
    public async Task<int> DeleteCity(Guid? Id)
    {
        City updateCity = await db.City.Where(x => x.Id == Id).FirstOrDefaultAsync();
        updateCity.IsActive = 0;
        await db.SaveChangesAsync();
        return 1;
    }
    [HttpPut]
    [Route("api/city/DeleteCitys/{Id}")]
    public async Task<int> DeleteCitys(Guid? Id)
    {
        City updateCity = await db.City.Where(x => x.Id == Id).FirstOrDefaultAsync();
        updateCity.IsActive = 1;
        await db.SaveChangesAsync();
        return 3;
    }
