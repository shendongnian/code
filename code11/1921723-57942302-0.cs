    [CustomEditor(typeof(ScriptableObjects.OBJ))]
    public class OBJEditor: UnityEditor.Editor 
    {
        ScriptableObjects.OBJ obj = null;
        protected void OnEnable()
        {
            obj = (ScriptableObjects.OBJ)target;
        }
        public override void OnInspectorGUI() 
        {
            serializedObject.Update();
            
            _ = DrawDefaultInspector();
            
            EditorGUI.BeginChangeCheck();
            obj.Offset = EditorGUILayout.Vector2Field("Offset", obj.Offset);
            ...
            bool somethingChanged = EditorGUI.EndChangeCheck();
            if(somethingChanged)
            {
                EditorUtility.SetDirty(obj);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
