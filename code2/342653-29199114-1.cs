    lvs.Filter = new Predicate<object>(ItemIndexFilter);
    List<Note> note_list = new List<Note>();
    for (int i = 0; i < lvs.Count; i++)
         {                   
            note_list.Add((Note)lvs.GetItemAt(i));    
         }
    var observe = new ObservableCollection<Note>(note_list);
    items=observe;
