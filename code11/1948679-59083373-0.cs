    [HttpPost]
    [Route("Paging")]
    public async Task <ActionResult<IQueryable<City>>> Paging(int CurrentPage=1)
        {
        var abc= await _dropdowncontext.cities.OrderBy(x=>x.CityId).Skip((CurrentPage - 1) * 5).Take(5).ToListAsync();
    
            if (!abc.Any())
                return NotFound();
            return Ok(abc);
        }
