    ObservableCollection<Game> Games { get; set; }
    
    ...
    var db = new SQLiteConnection(_dbPath);
    
    Games = new ObservableCollection<Game>(db.Table<Game>().OrderBy(x => x.GameNaam).ToList());
