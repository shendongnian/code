     Game _selectedGame;
     public Game SelectedGame
     {
         get { return _selectedGame; }
         set { 
            SetProperty(ref _selectedGame, value); 
            // code to add in the setter
            if (value != null) 
               InsertGame();
            //----------------------------
         }
     }
