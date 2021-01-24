    public class ScenePathManager : MonoBehaviour
    {
        [Serializable]
        public class SceneElement
        {
            string Path;
            string Name;
        }
        public List<SceneElement> Scenes = new List<SceneElement>();
        // Loading scenes by path is more secure
        // since two scenes might have the same name
        // but the path is allways unique
        public void LoadScene(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                Debug.LogError("Given path is null or empty!", this);
                return;
            }
            if(!Scenes.Any(s=>string.Equals(s.Path, path)))
            {
                Debug.LogError("Given path " + path + " is invalid!", this);
                return;
            }
            // Load the Scene here e.g. using
            SceneManager.LoadSceneAsync(path);
        }
    }
