    // Made these two const btw
    private const float PAD_SIZE = 2f;
    private const float FOOTER_HEIGHT = 10f;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Move this up
        EditorGUI.BeginProperty(position, GUIContent.none, property);
        {
            // Here we add the foldout using a single line height, the label and change
            // the value of property.isExpanded
            property.isExpanded = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, lineHeight), property.isExpanded, label);
            // Now you want to draw the content only if you unfold this property
            if (property.isExpanded)
            {
                // Optional: Indent the content
                //EditorGUI.indentLevel++;
                //{
                // reduce the height by one line and move the content one line below
                position.height -= lineHeight;
                position.y += lineHeight;
                var sceneAssetProperty = GetSceneAssetProperty(property);
                // Draw the Box Background
                position.height -= FOOTER_HEIGHT;
                GUI.Box(EditorGUI.IndentedRect(position), GUIContent.none, EditorStyles.helpBox);
                position = boxPadding.Remove(position);
                position.height = lineHeight;
                // Draw the main Object field
                label.tooltip = "The actual Scene Asset reference.\nOn serialize this is also stored as the asset's path.";
                var sceneControlID = GUIUtility.GetControlID(FocusType.Passive);
                EditorGUI.BeginChangeCheck();
                {
                    // removed the label here since we already have it in the foldout before
                    sceneAssetProperty.objectReferenceValue = EditorGUI.ObjectField(position, sceneAssetProperty.objectReferenceValue, typeof(SceneAsset), false);
                }
                var buildScene = BuildUtils.GetBuildScene(sceneAssetProperty.objectReferenceValue);
                if (EditorGUI.EndChangeCheck())
                {
                    // If no valid scene asset was selected, reset the stored path accordingly
                    if (buildScene.scene == null) GetScenePathProperty(property).stringValue = string.Empty;
                }
                position.y += paddedLine;
                if (!buildScene.assetGUID.Empty())
                {
                    // Draw the Build Settings Info of the selected Scene
                    DrawSceneInfoGUI(position, buildScene, sceneControlID + 1);
                }
                // Optional: If enabled before reset the indentlevel
                //}
                //EditorGUI.indentLevel--;
            }
        }
        EditorGUI.EndProperty();
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var sceneAssetProperty = GetSceneAssetProperty(property);
        // Add an additional line and check if property.isExpanded
        var lines = property.isExpanded ? sceneAssetProperty.objectReferenceValue != null ? 3 : 2 : 1;
        // If this oneliner is confusing you - it does the same as
        //var line = 3; // Fully expanded and with info
        //if(sceneAssetProperty.objectReferenceValue == null) line = 2;
        //if(!property.isExpanded) line = 1;
        return boxPadding.vertical + lineHeight * lines + PAD_SIZE * (lines - 1) + FOOTER_HEIGHT;
    }
    
