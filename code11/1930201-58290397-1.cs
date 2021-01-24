    public class MySceneManager : MonoBehaviour
    {
        private static MySceneManager instance;
        // Lazy initialization
        public static MySceneManager Instance
        {
            if(instance) return instance;
            instance = new GameObject ("MySceneManager").AddComponent<MySceneManager>();
            Object.DontDestroyOnLoad(instance.gameObject);
        }
        
        private int lastLoadedScene = 0;
    
        public void LoadScene(int index)
        {
            StartCoroutine(loadNextScene(index));
        }
       
        private IEnumerator loadNextScene(int index)
        {   
            // Instead of the index get the actual current scene instance
            var currentScene = SceneManager.GetActiveScene();
            var _async = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    
          
            _async.allowSceneActivation = false;
            while (_async.progress < 0.9f)
            {
                
                yield return null;
            }
    
            _async.allowSceneActivation = true;
            
            while (!_async.isDone)
            {
                yield return null;
            }
            // You have to do this before otherwise you might again
            // get by index the previous scene
            if (lastLoadedScene >= 0) 
            {  
                 var unloadAsync = SceneManager.UnloadSceneAsync(currentScene);
                yield return new WaitUntil(()=>unloadAsync.isDone);
            }
            
    
            var newScene = SceneManager.GetSceneByBuildIndex(index);    
           
            SceneManager.SetActiveScene(newScene);
    
            lastLoadedScene = index;
        }
    }
