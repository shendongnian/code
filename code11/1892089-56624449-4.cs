    public class DeathCounter : Respawn
    {
        public Text DeathCount;
        // automatically called when scene is reloaded
        private void OnEnable()
        {
            DeathCount.text = deaths.ToString();
        }
    }
