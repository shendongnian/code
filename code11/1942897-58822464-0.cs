    // specific list of animals in the chosen shelter -by Id-
    [HttpGet("{id}/animals")]
    public IActionResult animals(int ShelterId) {
        var infoAnimals = ShelterDatabase.Shelter.Animals;
        return new ObjectResult(infoAnimals);
    } 
