    public class TestingEditorWindow : EditorWindow
    {
        const int width = 340;
        const int height = 420;
        private SerializedProperty _conversations;
    
        private Test currentTestInstance;
    
        public static void ConversationsSystem(Test testInstance)
        { 
            var x = (Screen.currentResolution.width - width) / 2;
            var y = (Screen.currentResolution.height - height) / 2;
    
            var window = GetWindow<TestingEditorWindow>();
            window.position = new Rect(x, y, width, height);
    
            window.currentTestInstance = testInstance;
        }
    
        private void OnGUI()
        {
            if(! currentTestInstance)
            {
                EditorGUILayout.HelpBox("No Test instance selected!", MessageType.Error);
                return;
            }
    
            var serializedObject = new SerializedObject(currentTestInstance);
    
            _conversations = serializedObject.FindProperty("conversations");
        }
    }
