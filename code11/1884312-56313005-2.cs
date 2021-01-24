    public class LevelManager : MonoBehaviour
    {
        // Assign levels here through the inspector
        public List<Level> Levels;
    
        public void LoadLevel()
        {
            Level level = Levels.First(x => x.CarLevel == Settings.LevelSelected);
            // Do whatever you want with your level
        } 
    }
