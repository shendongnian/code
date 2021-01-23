    public class GameService {
        private IGame game;
        public GameService(IGame game) { this.game = game; }
        public void PlayCards(Guid playerId, List<Card> cards) {
            // ...
        }
    }
