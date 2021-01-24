    public void OnEnable()
    {
        //_target = (PickupObjects)target;
        _myList = new ReorderableList(serializedObject, serializedObject.FindProperty("pickUpObjects"))
        {
            draggable = true,
            // I wouldn't show the Add button
            // since you have your own add functionality
            displayAdd = false,
            // I wouldn't show the remove button either
            // since you want a custom button for removing items
            displayRemove = false,
            drawHeaderCallback = rect => EditorGUI.LabelField(rect, "My Reorderable List", EditorStyles.boldLabel),
            drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                var element = _myList.serializedProperty.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width - 20, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
                if (GUI.Button(new Rect(rect.x + rect.width - 20, rect.y, 20, EditorGUIUtility.singleLineHeight), "X"))
                {
                    var obj = (GameObject) element.objectReferenceValue;
                    var boxCollider = obj.GetComponent<BoxCollider>();
                    if (boxCollider) DestroyImmediate(boxCollider);
                    var picker = obj.GetComponent<Whilefun.FPEKit.FPEInteractablePickupScript>();
                    if(picker) DestroyImmediate(picker);
                    _myList.serializedProperty.DeleteArrayElementAtIndex(index);
                }
            }
        };
    }
