C#
using UnityEditor;
using UnityEngine;
using System.Reflection;
[CustomEditor(typeof(ModifierMB))]
public class ModifierMBEditor : Editor
{
    public SerializedProperty nameOfListToEdit;
    void OnEnable() {
        nameOfListToEdit = serializedObject.FindProperty("nameOfListToEdit");
    }
    public override void OnInspectorGUI() {
        serializedObject.Update();
        // use Reflection to get the names of the fields
        string[] fieldNames = typeof(ModifierMB).GetFields()
            .Select(field => field.Name)
            .Where(name => name.EndsWith("Inventory"))
            .ToArray();
        int index = 0;
        index = EditorGUILayout.Popup(index, fieldNames);
        nameOfListToEdit.stringValue = fieldNames[index];
        serializedObject.ApplyModifiedProperties();
    }
}
Then, in the MonoBehavior...
C#
using UnityEngine;
using System.Reflection;
public class ModifierMB : MonoBehavior
{
    string nameOfListToEdit;
    BOAT objectContainingLists;
    public void ModifyLists() {
        FieldInfo fieldToEdit = typeof(objectContainingLists).GetField(nameOfListToEdit);
        List<BlockScriptableObject> listToEdit = fieldToEdit.GetValue(objectContainingLists);
        // modify listToEdit here ################
        Debug.Log(listToEdit);
        // #######################################
    }
}
Note that this isn't an ideal solution, because it uses Reflection every time you want to modify the list. Reflection is generally very slow and inefficient, you might want to find a way to cache the List that is going to be edited. For example, you could do the Reflection when the MonoBehavior is initialized, and then cache the `listToEdit` in a field, to be accessed/modified later.
Caching the `listToEdit` in a field could be done along these lines:
C#
using UnityEditor;
using UnityEngine;
using System.Reflection;
[CustomEditor(typeof(ModifierMB))]
public class ModifierMBEditor : Editor
{
    public SerializedProperty nameOfListToEdit;
    void OnEnable() {
        nameOfListToEdit = serializedObject.FindProperty("nameOfListToEdit");
    }
    public override void OnInspectorGUI() {
        serializedObject.Update();
        // use Reflection to get the names of the fields
        string[] fieldNames = typeof(ModifierMB).GetFields()
            .Select(field => field.Name)
            .Where(name => name.EndsWith("Inventory"))
            .ToArray();
        int index = 0;
        index = EditorGUILayout.Popup(index, fieldNames);
        nameOfListToEdit.stringValue = fieldNames[index];
        serializedObject.ApplyModifiedProperties();
        ModifierMB modifier = (ModifierMB)target; 
        modifier.listToEdit = typeof(modifier.objectContainingLists).GetField(
                                      fieldNames[index]).GetValue(
                                              modifier.objectContainingLists);
    }
}
Then, in the MonoBehavior...
C#
using UnityEngine;
using System.Reflection;
public class ModifierMB : MonoBehavior
{
    string nameOfListToEdit;
    public BOAT objectContainingLists;
    public List<BlockScriptableObject> listToEdit;
    public void ModifyLists() {
        // modify listToEdit here ################
        Debug.Log(listToEdit);
        // #######################################
    }
}
