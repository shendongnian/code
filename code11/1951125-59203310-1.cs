    public class MenuButtons : MonoBehaviour
    {
        public void Load()
        {
            // Only reads the save file into the SaveSystem.Data
            SaveSystem.LoadPlayer();
        }
        public void Save()
        {
            // Only write SaveSystem.Data to the file
            SaveSystem.SavePlayer();
        }
    }
