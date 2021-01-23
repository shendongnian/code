    abstract class GameState { }
    class Menu : GameState { }
    class Game : GameState
    {
        private class _Playing : GameState { }
        private class _Paused : GameState { }
    
        static readonly GameState Playing = new _Playing();
        static readonly GameState Paused = new _Playing();
    }
