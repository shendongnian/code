    public class DeathCounter : Respawn
    {
        public Text DeathCount;
        private void OnEnable()
        {
            DeathCount.text = Respawn.deaths;
        }
    }
