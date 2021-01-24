    using UnityEditor
    [CustomEditor(typeof(ScenePathManager))]
    private partial class ScenePathManagerEditor : Editor
    {
        private SerializedProperty _scenes;
    
        private ReorderableList _sceneList;
    
        private void OnEnable()
        {
            _scenes = serializedObject.FindProperty("Scenes");
    
            _sceneList = new ReorderableList(serializedObject, _scenes)
            {
                displayAdd = true,
                displayRemove = true,
                draggable = true,
                drawHeaderCallback = rect => EditorGUI.LabelField(rect, "Scenes"),
                drawElementCallback = (rect, index, selected, highlighted) =>
                {
                    var element = _scenes.GetArrayElementAtIndex(index);
                    var path = element.FindPropertyRelative("Path");
                    var name = element.FindPropertyRelative("Name");
    
                    // get the SceneAsset that belongs to the current path
                    var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(path.stringValue);
    
                    // draw an object field in the editor
                    scene = (SceneAsset)EditorGUI.ObjectField(new Rect(rect.x, rect.y, rect.width * 0.5f, EditorGUIUtility.singleLineHeight), scene, typeof(SceneAsset), false);
    
                    // write back the path of the SceneAsset
                    path.stringValue = AssetDatabase.GetAssetOrScenePath(scene);
                    name.stringValue = scene.name;
                },
                elementHeight = EditorGUIUtility.singleLineHeight * 1.2f
            };
        }
    
        public override void OnInspectorGUI()
        {
            DrawScriptField();
    
            serializedObject.Update();
    
            // Disable editing of the list on runtime
            EditorGUI.BeginChangeCheck();
            _sceneList.DoLayoutList();
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                ((SceneLoader)target).AddListsToBuildSettings();
            }
    
            serializedObject.ApplyModifiedProperties();
        }
    
        // Draws the usual Script field in the Inspector
        private void DrawScriptField()
        {
            // Disable editing
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((ScenePathManager)target), typeof(ScenePathManager), false);
            EditorGUI.EndDisabledGroup();
    
            EditorGUILayout.Space();
        }
    }
    
