    if (_lvwGames.IsHandleCreated) {
    
        Action addGameToList = () => {
            string id = game.id.ToString();
            var li = new ListViewItem(id, 0);
            li.SubItems.Add(game.title);
            ....
            _lvwGames.Items.Add(li);
        };
    
        if (_lvwGames.InvokeRequired) {                        
            _lvwGames.Invoke(addGameToList);
        } else {
            addGameToList();
        }
    }
