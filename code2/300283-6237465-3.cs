    public void Create(string name)
      {
        Animal animal = new Animal { Name = input.Name};
       animalRepository.UpdateOrInsert(animal);
      }
  
