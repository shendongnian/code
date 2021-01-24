    public IActionResult animals(int ShelterId)
    {
        var shelters = ShelterDatabase.Shelter;  // this should be collection of shelters
        var shelter = shelters.FirstOrDefault(_ => _.ShelterId == ShelterId);
        if (shelter == null)
        {
            return NotFound();
        }
        var animals = shelter.Animals;
        return new ObjectResult(animals);
    }
