    public class PlayersController
    {
        private void Start()
        {
            string json = "your json";
            var players = JsonUtility.FromJson<PlayerContainer>(json);
        }
    }
