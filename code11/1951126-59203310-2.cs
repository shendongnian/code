    public class Player : MonoBehaviour
    {
        // Load the player values on startup from SaveSystem.Data
        private void Awake ()
        {
            var data = SaveSystem.Data;
            if(data == null) return;
    
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;
        }
    
        // Now it is up to you when and how often you want the player to save its data
        // I would do it e.g. in OnDestroy
        // so everytime the scene is changed
        private void OnDestroy ()
        {
            // Only populates the SaveSystem.Data
            // without necessarily writing the file
            SaveSystem.Data = new PlayerData(this);
        }
    }
