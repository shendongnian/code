    MessagingCenter.Send<object,ObservableCollection<Unit>>(Application.Current, Constants._listUpdateContract, myList);
    MessagingCenter.Subscribe<object, ObservableCollection<Unit>>(Application.Current, Constants._listUpdateContract, (s, a) =>
            {
                //populate list code
                System.Diagnostics.Debug.WriteLine(a.ToString());
            });
