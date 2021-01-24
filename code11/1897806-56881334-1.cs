    public static class GameObjectExtensions
    {
        public static void SetDontDestroyOnLoad(this GameObject gameObject, bool value)
        {
            if (value)
            {
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
            }
            else
            {
                // add a new temporal GameObject to the active scene
                // therefore we needed to make sure before to set the
                // SceneManager.activeScene correctly
                var newGO = new GameObject();
                // This moves the gameObject out of the DontdestroyOnLoad Scene
                // back into the currently active scene
                gameObject.transform.SetParent(newGO.transform, true);
                // remove its parent and set it back to the root in the 
                // scene hierachy
                gameObject.transform.SetParent(null, true);
                // remove the temporal newGO GameObject
                UnityEngine.Object.Destroy(newGO);
            }
        }
    }
    
