    MessagingCenter.Send<object,ObservableCollection<ListItem>>(Application.Current, Constants._listUpdateContract, myList);
    MessagingCenter.Subscribe<object, ObservableCollection<ListItem>>(Application.Current, Constants._listUpdateContract, (s, a) =>
            {
                //populate list code
                System.Diagnostics.Debug.WriteLine(a.ToString());
            });
