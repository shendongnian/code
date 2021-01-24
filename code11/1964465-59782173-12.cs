    public override void OnInspectorGUI()
    {
        var list = serializedObject.FindProperty("pickUpObjects");
        serializedObject.Update();
        if(picked)
        {
            picked = false;
            foreach(var newEntry in pickeditems)
            {
                // check if already contains this item
                bool alreadyPresent = false;
                for(var i=0; i < list.arraySize; i++)
                {
                    if((GameObject)list.GetArrayElementAtIndex(i).objectReferenceValue == newEntry)
                    {
                        alreadyPresent = true;
                        break; 
                    }
                }
                if(alreadyPresent) continue;
                // Otherwise add via the serializedProperty
                list.arraySize++;
                list.GetArrayElementAtIndex(list.arraySize - 1).objectReferenceValue = newEntry;
            }
            pickeditems.Clear();
        }
        _myList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
