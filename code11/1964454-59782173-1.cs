    public void OnEnable()
    {
        //_target = (PickupObjects)target;
        _myList = new ReorderableList(serializedObject, serializedObject.FindProperty("pickUpObjects"))
        {
            draggable = true,
            displayHeader = true,
            // I wouldn't show the Add button
            // since you have your own add functionality
            displayAddButton = false,
            // I wouldn't show the remove button either
            // since you want a custom button for removing items
            displayRemoveButton = false,
            drawHeaderCallback = rect => EditorGUI.LabelField(rect, "My Reorderable List", EditorStyles.boldLabel),
            drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                var element = _myList.serializedProperty.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width - 10, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
                if(GUI.Button(new Rect(rect.x + rect.width -10, rect.y, 10, EditorGUIUtility.singleLineHeight), "X"))
                {
                    var obj = element.objectReferenceValue;
                    var boxCollider = obj.GetComponent<BoxCollider>();
                    if(boxCollider) DestroyImmediately(boxCollider);
                    var picker = obj.GetComponent<Whilefun.FPEKit.FPEInteractablePickupScript>();
                    if(picker) DestroyImmediately(picker);
                     _myList.serializedProperty.DeleteArrayElementAtIndex(index);
                }
            }
        }
    }
