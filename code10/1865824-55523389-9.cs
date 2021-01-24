    public class ButtonSpawner : MonoBehaviour
    {
        // somehow get this reference e.g. via drag and drop in the Inspector
        [SerializeField] private ScenePathManager _scenePathManager;
    
        // reference your prefab here
        [SerializeField] private Button _buttonPrefab;
    
        public void SpawnButtons()
        {
            foreach(var scene in _scenePathManager.Scenes)
            {
                // ofcourse you will want to spawn this maybe as
                // child of another object or position them etc
                var button = Instantiate(_buttonPrefab);
    
                // However you want to get the text. You could also give each button
                // special MonoBehaviour class and reference all components you need
                var buttonText = button.GetComponentInChildren<Text>(true);
            
                buttonText.text = scene.Name;
    
                button.onClick.AddListener(() =>
                {
                    _scenePathManager.LoadScene(scene.Path);
                });
            }
        }
    }
