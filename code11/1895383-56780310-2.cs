    [CustomEditor(typeof(Weapon))]
    public class Weapon_Editor : Editor
    {
        SerializedProperty model;
        SerializedProperty weaponType;
        SerializedProperty slotType;
        SerializedProperty weaponTextureMaps;
    
        // Link all script fields
        public void OnEnable()
        {
            model = serializedObject.FindProperty("modelMesh");
            weaponType = serializedObject.FindProperty("weaponType");
            slotType = serializedObject.FindProperty("slotType");
            weaponTextureMaps = serializedObject.FindProperty("weaponTextureMaps");
        }
    
        public override void OnInspectorGUI()
        {
            // Draw the Script field
            EditorGUI.BeginDisabledGroup(true);
            {
                EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((Weapon)target), typeof(Weapon), false);
            }
            EditorGUI.EndDisabledGroup();
            // load current values into the serialized fields
            serilaizedObject.Update();
    
            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.PropertyField(model);
            }
            // runs everytime the model is changed
            if (EditorGUI.EndChangeCheck())
            {
                // get the renderer fromt he SerializedProperty
                var renderer = ((GameObject)model.objectReferenceValue).GetComponent<Renderer>();
    
                int totalMaterials = renderer.sharedMaterials.Length;
    
                weaponTextureMaps.arraySize = totalMaterials;
    
                // set the material references
                for (var i = 0; i < totalMaterials; i++)
                {
                    weaponTextureMaps.GetArrayElementAtIndex(i).FindPropertyRelative("material").objectReferenceValue = renderer.sharedMaterials[i];
                }
            }
    
            EditorGUILayout.PropertyField(weaponType);EditorGUILayout.PropertyField(slotType);
    
            // Note you have to pass true in order to see sub-fields
            EditorGUILayout.PropertyField(weaponTextureMaps, true);
            // Note that without that any changes to SerializedProperties does absolutely nothing
            serializedObject.ApplyModifiedProperties();
        }
    }
    #endif
