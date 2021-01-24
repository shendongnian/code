    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Pet> Create(Pet pet)
    {
        pet.Id = _petsInMemoryStore.Any() ? 
                 _petsInMemoryStore.Max(p => p.Id) + 1 : 1;
        _petsInMemoryStore.Add(pet);
    
        return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
    }
