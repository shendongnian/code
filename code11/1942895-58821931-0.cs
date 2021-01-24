    //api/shelters/0
    [HttpGet("[controller]/{id}")] 
    public IActionResult sherlter(int ShelterId) {
        var shelter = ShelterDatabase.Shelter;
        return new ObjectResult(shelter);
    }
    //api/shelters/animals/0
    [HttpGet("[controller]/[action]/{id}")] 
    public IActionResult animals(int ShelterId) {
        var infoAnimals = ShelterDatabase.Shelter.Animals;
        return new ObjectResult(infoAnimals);
    }
