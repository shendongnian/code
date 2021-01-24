    public class MySceneManager : MonoBehaviour
    {
        private static MySceneManager instance;
        // Lazy initialization
        public static MySceneManager Instance
        {
            if(instance) return instance;
            instance = new GameObject ("MySceneManager").AddComponent<MySceneManager>();
            DontDestroyOnLoad(instance);
        }
    
        public void LoadScene(int index)
        {
            StartCoroutine(loadNextScene(index));
        }
       
        private IEnumerator loadNextScene(int index)
        { 
            // I didn't completely go through your ObjectPooler but I guess you need to do this
            ObjectPooler.Instance.ReleaseAll();
  
            // Instead of the index get the actual current scene instance
            var currentScene = SceneManager.GetActiveScene();
            var _async = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    
          
            _async.allowSceneActivation = false;
            yield return new WaitWhile(() => _async.progress < 0.9f);
    
            _async.allowSceneActivation = true;
            
            yield return new WaitUntil(() => _async.isDone);
            // You have to do this before otherwise you might again
            // get by index the previous scene 
            var unloadAsync = SceneManager.UnloadSceneAsync(currentScene);
            yield return new WaitUntil(()=>unloadAsync.isDone);            
    
            var newScene = SceneManager.GetSceneByBuildIndex(index);    
           
            SceneManager.SetActiveScene(newScene);
        }
    }
