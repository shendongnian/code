    public class PrefabReplace : EditorWindow
    {
        [SerializeField] private GameObject _prefab;
    
        private bool _selectionChanged;
        private string _objectsToSearch = "";
        private List<GameObject> _foundObjects = new List<GameObject>();
        private readonly GUIStyle _guiStyle = new GUIStyle(); //create a new variable
        private int _count;
        private bool _addFoundObjects;
        private bool _keepNames = true;
        private bool _keepPlaceInHierarchy = true;
        private static GameObject _newObject;
        private static Component[] _components;
    
        [MenuItem("Tools/Prefab Replace")]
        private static void CreateReplaceWithPrefab()
        {
            const int width = 340;
            const int height = 600;
    
            var x = (Screen.currentResolution.width - width) / 2;
            var y = (Screen.currentResolution.height - height) / 2;
    
            GetWindow<PrefabReplace>().position = new Rect(x, y, width, height);
        }
    
        private void OnGUI()
        {
            _guiStyle.fontSize = 15; //change the font size
            Searching();
            GUILayout.Space(10);
            Replacing();
            GUILayout.Space(50);
            Settings();
        }
    
        private void Searching()
        {
            //GUI.Label(new Rect(10, 15, 150, 20), "Search by name", guiStyle);
            _objectsToSearch = GUI.TextField(new Rect(90, 35, 150, 20), _objectsToSearch, 25);
    
            if (_objectsToSearch != "")
            {
                GUI.enabled = true;
            }
            else
            {
                GUI.enabled = false;
                _count = 0;
            }
            GUILayout.Space(15);
            if (GUILayout.Button("Search"))
            {
                _foundObjects = new List<GameObject>();
                _count = 0;
    
                foreach (var gameObj in FindObjectsOfType<GameObject>().Where(gameObj => gameObj.name == _objectsToSearch))
                {
                    _count += 1;
                    _foundObjects.Add(gameObj);
                    foreach (Transform child in gameObj.transform)
                    {
                        _count += 1;
                        _foundObjects.Add(child.gameObject);
                    }
                }
    
                if (_foundObjects.Count == 0)
                {
                    _count = 0;
                }
            }
    
            GUI.enabled = true;
            EditorGUI.LabelField(new Rect(90, 65, 210, 15), "Number of found objects and childs");
            GUI.TextField(new Rect(90, 80, 60, 15), _count.ToString(), 25);
    
            GUILayout.Space(100);
            GUI.enabled = _count > 0;
            if (GUILayout.Button("Replace found objects"))
            {
                if (_prefab != null)
                {
                    InstantiatePrefab(_foundObjects);
                }
            }
    
            GUI.enabled = true;
        }
    
        private void Replacing()
        {
            GUILayout.Space(20);
            GUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Label("Replacing");
            GUILayout.Space(20);
    
            _prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false);
    
            var selection = Selection.objects.OfType<GameObject>().ToList();
    
            if (_selectionChanged)
            {
                if (selection.Count == 0)
                {
                    GUI.enabled = false;
                }
    
                for (var i = selection.Count - 1; i >= 0; --i)
                {
                    var selectedObject = selection[i];
                    if (_prefab != null && selection.Count > 0 &&
                        selectedObject.scene.name != null
                        && _prefab != PrefabUtility
                        .GetCorrespondingObjectFromSource(selectedObject))
                    {
                        GUI.enabled = true;
                    }
                    else
                    {
                        GUI.enabled = false;
                    }
                }
            }
            else
            {
                GUI.enabled = false;
            }
    
            if (GUILayout.Button("Replace"))
            {
                InstantiatePrefab(selection);
                _selectionChanged = false;
            }
    
            GUILayout.Space(10);
            GUI.enabled = true;
            EditorGUILayout.LabelField("Selection count: " + Selection.objects.OfType<GameObject>().Count());
    
            GUILayout.EndVertical();
        }
    
        private void Settings()
        {
            _keepPlaceInHierarchy = GUILayout.Toggle(_keepPlaceInHierarchy, "Keep order place in hierarchy");
            _keepNames = GUILayout.Toggle(_keepNames, "Keep names");
        }
    
        private void OnInspectorUpdate()
        {
            Repaint();
        }
    
        private void OnSelectionChange()
        {
            _selectionChanged = true;
        }
    
        private void InstantiatePrefab(IReadOnlyList<GameObject> selection)
        {
            if (_prefab == null || selection.Count <= 0) return;
    
            for (var i = selection.Count - 1; i >= 0; --i)
            {
                var selected = selection[i];
                _components = selected.GetComponents(typeof(MonoBehaviour));
    
                //if (components.Length == 0)
                //{
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(selected.scene.name));
    
                var prefabType = PrefabUtility.GetPrefabAssetType(_prefab);
                //GameObject newObject;
    
                if (prefabType == PrefabAssetType.Regular)
                {
                    _newObject = (GameObject)PrefabUtility.InstantiatePrefab(_prefab);
                }
                else
                {
                    _newObject = Instantiate(_prefab);
    
                    if (_keepNames == false)
                    {
                        _newObject.name = _prefab.name;
                    }
                }
                if (_newObject == null)
                {
                    Debug.LogError("Error instantiating prefab");
                    break;
                }
    
                Undo.RegisterCreatedObjectUndo(_newObject, "Replace With Prefabs");
                _newObject.transform.parent = selected.transform.parent;
                _newObject.transform.localPosition = selected.transform.localPosition;
                _newObject.transform.localRotation = selected.transform.localRotation;
                _newObject.transform.localScale = selected.transform.localScale;
                if (_keepPlaceInHierarchy)
                {
                    _newObject.transform.SetSiblingIndex(selected.transform.GetSiblingIndex());
                }
                if (_keepNames)
                {
                    _newObject.name = selected.name;
                }
    
                foreach (var comp in _components)
                {
                    _newObject.Init(comp);
                }
    
                Undo.DestroyObjectImmediate(selected);
                //}
            }
        }
    }
