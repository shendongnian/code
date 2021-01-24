    public class LevelSelector : MonoBehaviour
    {
        public Button[] levelButtons;
        public int levelunlocked = 1;
        public int levelReached = PlayerPrefs.GetInt("levelReached", levelunlocked);
        private void Start()
        {
    
            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (i + 1 > levelReached)
                {
                    levelButtons[i].interactable = false;
                }
            }
        }
    }
