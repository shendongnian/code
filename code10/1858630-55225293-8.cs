    public class SearchableWindow : EditorWindow
    {
        private string searchString = "";
    
        [MenuItem("Tools/Searching")]
        private static void Searching()
        {
            const int width = 340;
            const int height = 420;
    
            var x = (Screen.currentResolution.width - width) / 2;
            var y = (Screen.currentResolution.height - height) / 2;
    
            GetWindow<SearchableWindow>().position = new Rect(x, y, width, height);
        }
    
        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            GUILayout.FlexibleSpace();
            searchString = EditorGUILayout.TextField(searchString, EditorStyles.toolbarTextField);
            EditorGUILayout.EndHorizontal();
    
            var items = Selection.gameObjects;
            // Do comparison here. For example
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].name.Contains(searchString))
                {
                    EditorGUILayout.LabelField(items[i].name);
                }
            }
        }
        private void OnSelectionChange()
        {
            Repaint();
        }
    }
