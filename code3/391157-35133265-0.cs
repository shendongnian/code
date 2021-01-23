    Dog pet1 = new Dog();
            Dog pet2 = new Dog();
            Dog pet3 = new Dog();
            Dog pet4 = new Dog();
            //create a list of pets and add your pets to them
            List<Dog> pets = new List<Dog>();
            pets.Add(pet1);
            pets.Add(pet2); 
            pets.Add(pet3);
            pets.Add(pet4);
            //Using a for each loop to go through each element in the array and execute identical actions on each 
            //element
            foreach (Dog pet in pets)
            {
                pet.SetName("Fido");
            }
            //or create a for each loop that will allow you to know the position 
            //you are currenly at in the arry as the integer of i increments in the loop
            for (int i = 0; i <= pets.Count; i++)
            {
                pets[i].SetName("Fido");
            }
