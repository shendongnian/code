    public class GameListViewModel : INotifyPropertyChanged
    {
        public void InsertGame(Game currentGame)
        {
            GameNaamEntry = currentGame.GameNaam;
        }
        ...
    }
