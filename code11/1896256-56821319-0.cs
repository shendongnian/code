        public ListViewerViewModel()
        {
            MyPeople = (People)Application.Current.Resources["theOneAndOnlyPeople"];
            MyPeople.Add(new Person("Able", "Baker"));
            MyPeople.Add(new Person("Carla", "Douglas"));
            MyPeople.Add(new Person("Ed", "Fiducia"));
        }
