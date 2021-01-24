    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof(SetupActions))]
    internal class SetupActionsEditor : Editor
    {
        private bool IsDirty;
    
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
    
            EditorGUI.BeginChangeCheck();
    
            var property = serializedObject.FindProperty(nameof(SetupActions.Actions));
    
            EditorGUILayout.PropertyField(property);
    
            IsDirty |= EditorGUI.EndChangeCheck();
    
            DoApplyButton();
    
            serializedObject.ApplyModifiedProperties();
        }
    
        private void DoApplyButton()
        {
            using (new EditorGUI.DisabledGroupScope(!IsDirty))
            {
                if (!GUILayout.Button("Apply"))
                    return;
    
                var actions = (SetupActions) target;
    
                actions.RegisterButtons();
    
                IsDirty = false;
            }
        }
    }
