    Dog dog = new Dog();
            
            //create a list of pets and add your pets to them
            List<Dog> pets = new List<Dog>();
            for (int i = 0; i <= 5; i++)
            {
                pets.Add(dog);
            }
            //Using a for each loop to go through each element in the array and execute identical actions on each 
            //element
            foreach (Dog pet in pets)
            {
                pet.SetName("Fido");
            }
