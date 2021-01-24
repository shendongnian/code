    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    
    [Serializable]
    public class MyTestClass
    {
    	public string stringMember;
    }
    
    public class MyTestMonoBehaviour : MonoBehaviour
    {
    	public List<MyTestClass> testList;
    }
    
    [CustomPropertyDrawer(typeof(MyTestClass))]
    public class ColorPointDrawer : PropertyDrawer
    {
    	public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
    	{
    		EditorGUI.PrefixLabel(position, label);
    		EditorGUI.PropertyField(position, property.FindPropertyRelative("stringMember"), GUIContent.none);
    	}
    }
    
    [CustomEditor(typeof(MyTestMonoBehaviour))]
    public class MyTestMonoBehaviourEditor : Editor
    {
    	const int NUM_LISTENTRIES = 5;
    
    	public override void OnInspectorGUI()
    	{
    		SerializedProperty testListProp = serializedObject.FindProperty("testList");
    
    		for (int i = 0; i < testListProp.arraySize; i++)
    		{
    
    			SerializedProperty MyTestClassProp = testListProp.GetArrayElementAtIndex(i);
    			SerializedProperty stringMemberProp = MyTestClassProp.FindPropertyRelative("stringMember");
    			EditorGUILayout.PropertyField(stringMemberProp);
    		}
    
    		if (GUILayout.Button("Generate List"))
    		{
    			testListProp.arraySize = 0;
    			for (int i = 0; i < NUM_LISTENTRIES; i++) {
    				testListProp.InsertArrayElementAtIndex(i);
    			}
    		}
    		serializedObject.ApplyModifiedProperties();
    	}
    }
     
