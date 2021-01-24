    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    using UnityEngine;
    
    public class Screenshot : MonoBehaviour
    {
        [SerializeField] private Vector2Int resolution = new Vector2Int(Screen.width * 4, Screen.height * 4);
        [SerializeField] private Camera _myCamera;
        [SerializeField] [Range(1,15)] private int _scale = 1;
        [SerializeField] private string _path = "";
        [SerializeField] private bool _showPreview = true;
        [SerializeField] private bool _isTransparent = false;
        [SerializeField] private string _lastScreenshot = "";
    
        private RenderTexture renderTexture;
    
        private string ScreenShotName(string path, int width, int height) 
        {
            strPath = $"{path}/screen_{width}x{height}_{System.DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
            _lastScreenshot = strPath;
            return strPath;
        }
    
        public void TakeScreenshot()
        {
            TakeScreenshot(_myCamera, _resolution, _scale, _path, _isTransparent, _showPreview);
        }
    
        public void TakeScreenshot(Camera camera, Vector2Int resolution, float scale, string path, bool isTransparent, bool showPreview)
        {
            var finalResolution = resolution * scale;
            if(!renderTexture) renderTexture = new RenderTexture(finalResolution.x, finalResolution.y, 24);
            myCamera.targetTexture = renderTexture;
    
            var tFormat = isTransparent ? TextureFormat.ARGB32 : TextureFormat.RGB24;
    
            var screenShot = new Texture2D(finalResolution.x, finalResolution.y, tFormat, false);
            myCamera.Render();
            RenderTexture.active = renderTexture;
            screenShot.ReadPixels(new Rect(0, 0, finalResolution.x, finalResolution.y), 0, 0);
            myCamera.targetTexture = null;
            RenderTexture.active = null; 
            var bytes = screenShot.EncodeToPNG();
            var filename = ScreenShotName(finalResolution.x, finalResolution.y);
    
            WriteFileAsync(filename, bytes);
        }
    
        private async void WriteFileAsync(string path, byte[] data)
        {
            using(var file = File.Open(path))
            {
                await file.WriteAsync(data, 0, data.Length);
            }
    
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            if(showPreview) Application.OpenURL(filename);
        }
    
        #if UNITY_EDITOR
        [CustomEditor(typeof(Screenshot))]
        private class ScreenshotEditor : Editor
        {
            private SerializedProperty resolution;
            private SerializedProperty myCamera;
            private SerializedProperty scale;
            private SerializedProperty path;
            private SerializedProperty showPreview;
            private SerializedProperty isTransparent;
            private SerializedProperty lastScreenshot;
    
            private void OnEnable()
            {
                resolution = serilaizedObject.FindProperty(nameof((Screenshot._resolution));
                myCamera = serilaizedObject.FindProperty(nameof((Screenshot._myCamera));
                scale = serilaizedObject.FindProperty(nameof((Screenshot._scale));
                path = serilaizedObject.FindProperty(nameof((Screenshot._path));
                showPreview = serilaizedObject.FindProperty(nameof((Screenshot._showPreview));
                isTransparent = serilaizedObject.FindProperty(nameof(Screenshot._isTransparent));
                lastScreenshot = serilaizedObject.FindProperty(nameof(Screenshot._lastScreenshot));
            }
    
            public override void OnInspectorGUI()
            {
                serializedObject.Update();
    
                EditorGUI.BeginDisabledGroup(true);
                {
                    EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((Screenshot)target), typeof(Screenshot), false);
                    EditorGUILayout.Space();
                }
                EditorGUI.EndDisabledGroup();
    
                EditorGUILayout.LabelField ("Resolution", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(resolution);
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(scale);
                EditorGUILayout.HelpBox("The default mode of screenshot is crop - so choose a proper width and height. The scale is a factor " +
                    "to multiply or enlarge the renders without loosing quality.",MessageType.None);
    
                EditorGUILayout.Space();
    
                EditorGUILayout.LabelField("Save Path", EditorStyles.boldLabel);
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.PropertyField(path, GUILayout.ExpandWidth(false));
                    if(GUILayout.Button("Browse",GUILayout.ExpandWidth(false)))
                    {
                        path = EditorUtility.SaveFolderPanel("Path to Save Images",path,Application.dataPath);
                    }
                } 
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.HelpBox("Choose the folder in which to save the screenshots ",MessageType.None);
                EditorGUILayout.Space();
    
                EditorGUILayout.PropertyField(isTransparent, new GUIContent("Transparent Background"));
    
                EditorGUILayout.LabelField("Select Camera", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(myCamera);
    
                if(!myCamera.objectReferenceValue) myCamera.objectReferenceValue = Camera.main;
    
                EditorGUILayout.PropertyField(isTransparent, new GUIContent("Transparent Background"));
                EditorGUILayout.HelpBox("Choose the camera of which to capture the render. You can make the background transparent using the transparency option.", MessageType.None);
                EditorGUILayout.Space();
    
                EditorGUILayout.BeginVertical();
                {
                    EditorGUILayout.LabelField ("Default Options", EditorStyles.boldLabel);
    
                    if(GUILayout.Button("Set To Screen Size"))
                    {
                        resolution.vector2ntValue = new Vector2Int((int)Handles.GetMainGameViewSize().x, (int)Handles.GetMainGameViewSize().y);
                    }
    
                    if(GUILayout.Button("Default Size"))
                    {
                        resolution.vector2ntValue = new Vector2Int(2560, 1440);
                        scale.intValue = 1;
                    }
                }
                EditorGUILayout.EndVertical();
    
                EditorGUILayout.Space();
                EditorGUILayout.LabelField ("Screenshot will be taken at " + resWidth*scale + " x " + resHeight*scale + " px", EditorStyles.boldLabel);
    
                if(GUILayout.Button("Take Screenshot", GUILayout.MinHeight(60)))
                {
                    if(string.IsNullOrWhitespae(path.stringValue))
                    {
                        path.stringValue = EditorUtility.SaveFolderPanel("Path to Save Images", path.stringValue, Application.dataPath);
                        Debug.Log("Path Set");
                        ((Screenshot)target).TakeHiResShot();
                    }
                    else
                    {
                        ((Screenshot)target).TakeHiResShot();
                    }
                }
    
                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();
    
                if(GUILayout.Button("Open Last Screenshot",GUILayout.MaxWidth(160),GUILayout.MinHeight(40)))
                {
                    if(lastScreenshot != "")
                    {
                        Application.OpenURL("file://" + lastScreenshot);
                        Debug.Log("Opening File " + lastScreenshot);
                    }
                }
    
                if(GUILayout.Button("Open Folder", GUILayout.MaxWidth(100), GUILayout.MinHeight(40)))
                {
                    Application.OpenURL("file://" + path.stringValue);
                }
    
                if(GUILayout.Button("More Assets", GUILayout.MaxWidth(100), GUILayout.MinHeight(40)))
                {
                    Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/publisher/5951");
                }
                EditorGUILayout.EndHorizontal();
    
                EditorGUILayout.HelpBox("In case of any error, make sure you have Unity Pro as the plugin requires Unity Pro to work.",MessageType.Info);
    
                serializedObject.ApplyModiefiedProperties();
            }
        }
    #endif
    }
