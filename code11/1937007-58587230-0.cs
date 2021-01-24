      List<Note> StockLIST = new List<Note>();
            StockLIST.Add(new Note() {Text="bbbb",Gender="fame",Date= DateTime.UtcNow });
            StockLIST.Add(new Note() { Text = "bbbb1", Gender = "fame", Date = DateTime.UtcNow });
            StockLIST.Add(new Note() { Text = "bbbb2", Gender = "fame", Date = DateTime.UtcNow });
            StockLIST.Add(new Note() { Text = "bbbb3", Gender = "fame", Date = DateTime.UtcNow });
            foreach (var item in StockLIST)
            {
                await App.Database.SaveNoteAsync(item);
            }
