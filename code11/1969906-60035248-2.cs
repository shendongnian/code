        #if UNITY_EDITOR
        using UnityEditor;
        using UnityEditorInternal;
        #endif
        ...
        #if UNITY_EDITOR
        [CustomEditor(typeof(test))]
        public class testEditor : Editor
        {
            ...
        }
        #endif
