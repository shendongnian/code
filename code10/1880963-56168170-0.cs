    string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "uuthemis.db"));
    using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
    {
        var iden = conn.Query<undang2>("SELECT identifier FROM undangundang WHERE identifier like 'inpres no%' and identifier like '%th 2018")
            .ToList();
        sqlList.ItemsSource = new ObservableCollection<undang2>(iden);
    }
