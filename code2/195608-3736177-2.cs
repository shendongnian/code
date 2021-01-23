            InstanceRepository repository = new InstanceRepository();
            var listOfCats = (IList<Cat>)repository.SomeTypeData(typeof(Cat));
            listOfCats.Add(new Cat());
            Cat firstCat = listOfCats[0];
            Console.WriteLine(listOfCats.GetType().FullName);
