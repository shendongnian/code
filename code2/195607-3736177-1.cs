            InstanceRepository repository = new InstanceRepository();
            var listOfCats = repository.SomeTypeData<Cat>();
            listOfCats.Add(new Cat());
            Cat firstCat = listOfCats[0];
            Console.WriteLine(listOfCats.GetType().FullName);
