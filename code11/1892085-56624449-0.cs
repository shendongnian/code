    public class DeathCounter : Respawn
    {
        public Text DeathCount;
        public void SetText(int text)
        {
            string deathsS = deaths.ToString();
            DeathCount.text = deathsS;
        }
    }
