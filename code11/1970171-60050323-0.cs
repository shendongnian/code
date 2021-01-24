    players = new List<Player>();
    players.Add(new Player("James"));
    players.Add(new Player("John"));
    players.Add(new Player("Jack"));
    players.Add(new Player("Hugo"));
    List<string> nameList = new List<string>();
    foreach (var item in players)
      {
         nameList.Add(item.Name);
      }
    autocomplete = FindViewById<AutoCompleteTextView>(Resource.Id.autocomplete);
    ArrayAdapter arrayAdapter = new ArrayAdapter(this, Resource.Layout.model, Resource.Id.nameTxt, nameList);
    autocomplete.Adapter = arrayAdapter;
