    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    
    public abstract class MyAbstractBaseClass : ScriptableObject
    {
    	public abstract void foo();
    }
    
    public class MyTestScriptableObject : MyAbstractBaseClass
    {
    	public string stringMember;
    	public override void foo()
    	{
    	}
    }
    
    public class MyTestMonoBehaviour : MonoBehaviour
    {
    	public int instanceID = 0;
    	public List<MyAbstractBaseClass> testList;
    }
    
    [CustomEditor(typeof(MyTestMonoBehaviour))]
    public class MyTestMonoBehaviourEditor : Editor
    {
    	const int NUM_LISTENTRIES = 5;
    
    	public override void OnInspectorGUI()
    	{
    		MyTestMonoBehaviour myScriptableObject = (MyTestMonoBehaviour)target;
    
    		SerializedProperty testListProp = serializedObject.FindProperty("testList");
    
    		MakeListElementsUnique(myScriptableObject, testListProp);
    
    		for (int i = 0; i < testListProp.arraySize; i++)
    		{
    
    			SerializedObject myTestScriptableObjectSO = new SerializedObject(testListProp.GetArrayElementAtIndex(i).objectReferenceValue);
    			SerializedProperty stringMemberProp = myTestScriptableObjectSO.FindProperty("stringMember");
    			EditorGUILayout.PropertyField(stringMemberProp);
    			myTestScriptableObjectSO.ApplyModifiedProperties();
    		}
    
    		if (GUILayout.Button("Generate List"))
    		{
    			testListProp.arraySize = NUM_LISTENTRIES;
    			for (int i = 0; i < NUM_LISTENTRIES; i++)
    				testListProp.GetArrayElementAtIndex(i).objectReferenceValue = ScriptableObject.CreateInstance<MyTestScriptableObject>();
    		}
    		serializedObject.ApplyModifiedProperties();
    	}
    
    	private void MakeListElementsUnique( MyTestMonoBehaviour scriptableObject, SerializedProperty testListProp )
    	{
    		SerializedProperty instanceIdProp = serializedObject.FindProperty("instanceID");
    		// stored instance id == 0: freshly created, just set the instance id of the game object
    		if (instanceIdProp.intValue == 0)
    		{
    			instanceIdProp.intValue = scriptableObject.gameObject.GetInstanceID();
    		}
    		// stored instance id != current instance id: copied!
    		else if (instanceIdProp.intValue != scriptableObject.gameObject.GetInstanceID())
    		{
    			// don't forget to change the instance id to the new game object
    			instanceIdProp.intValue = scriptableObject.gameObject.GetInstanceID();
    			// make clones of all list elements
    			for (int i = 0; i < testListProp.arraySize; i++)
    			{
    				SerializedProperty sp = testListProp.GetArrayElementAtIndex(i);
    				sp.objectReferenceValue = Object.Instantiate(sp.objectReferenceValue);
    			}
    		}
    	}
    
    }
