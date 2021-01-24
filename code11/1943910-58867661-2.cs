    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class SetupActions : MonoBehaviour
    {
        public CustomAction[] Actions;
    
        private void OnEnable()
        {
            // AddListener is non-persistent so register again
            RegisterButtons();
        }
    
        private static IEnumerator ChangeScene(string toLoad, string toUnload)
        {
            yield return SceneManager.LoadSceneAsync(toLoad);
            yield return SceneManager.UnloadSceneAsync(toUnload);
        }
    
        public void RegisterButtons()
        {
            foreach (var action in Actions)
            {
                var scene1 = action.Scene1;
                var scene2 = action.Scene2;
                var button = action.Button;
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => { StartCoroutine(ChangeScene(scene1, scene2)); });
            }
        }
    }
