[CustomEditor(typeof(DialogueTrigger))]
public class DialogueTriggerEditor : Editor
{
    private SerializedProperty _dialogues;
    private void OnEnable()
    {
        // do this only once here
        _dialogues = serializedObject.FindProperty("dialogue");
    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        serializedObject.Update();
        for (int i = 0; i &lt; _dialogues.arraySize; i++)
        {
            var dialogue = _dialogues.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(dialogue, new GUIContent("Dialogue " + i), true);
        }
        // Note: You also forgot to add this
        serializedObject.ApplyModifiedProperties();
    }
}
