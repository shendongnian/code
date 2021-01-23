       public MainViewModel()
       {
           SelectedPersonModel = new PersonModel();
           PersonList = new BindingList<PersonModel>();
           PersonList.Add(new PersonModel { FirstName = "A", LastName = "AA", Age = 19 });
           PersonList.Add(new PersonModel { FirstName = "B", LastName = "BB", Age = 25 });
           PersonList.Add(new PersonModel { FirstName = "C", LastName = "CC", Age = 30 });
    
          // Either add SelectedPerson to list
          PersonList.Add(SelectedPersonModel);
    
          // or set SelectedPersonModel to an item that already exists in the list
          SelectedPersonModel = PersonList.FirstOrDefault();
       }
