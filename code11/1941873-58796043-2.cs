using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
public static class EditorHelper
{
    public static List<SerializedProperty> GetExposedProperties(SerializedObject so, IEnumerable<string> namesToHide = null)
    {
        if (namesToHide == null) namesToHide = new string[] { };
        IEnumerable<FieldInfo> componentFields = so.targetObject.GetType().GetFields();
        List<SerializedProperty> exposedFields = new List<SerializedProperty>();
        foreach (FieldInfo info in componentFields)
        {
            bool displayInInspector = info.IsPublic && !Attribute.IsDefined(info, typeof(HideInInspector));
            displayInInspector = displayInInspector || (info.IsPrivate && Attribute.IsDefined(info, typeof(SerializeField)));
            displayInInspector = displayInInspector && !namesToHide.Contains(info.Name);
            if (displayInInspector){
                SerializedProperty prop = so.FindProperty(info.Name);
                if(prop != null)
                    exposedFields.Add(prop);
            }
        }
        return exposedFields;
    }
}
Then in your unity project create a folder called "Editor" and place this script inside it. The only changes that you need to make are changing "MyCustomScript" to the name of you class. Then in the OnEnable method modify the list of hidden properties to include the names of all the properties you want to be hidden.
using UnityEditor;
using System.Collections.Generic;
[CustomEditor(typeof(MyCustomScript))]
public class MyCustomScriptEditor : Editor
{
    private List<SerializedProperty> properties;
    private void OnEnable()
    {
        string[] hiddenProperties = new string[]{"SomeString2"}; //fields you do not want to show go here
        properties = EditorHelper.GetExposedProperties(this.serializedObject,hiddenProperties);
    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); - (standard way to draw base inspector)
        //We draw only the properties we want to display here
        foreach (SerializedProperty property in properties)
        {
            EditorGUILayout.PropertyField(property,true);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
Hope this helps.
