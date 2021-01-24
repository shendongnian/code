    public class FieldController : MonoBehaviour
    {
        [ContextMenu("Save")]
        public void SavePlan()
        {
            List<string> texts = new List<string>();
            foreach (InputField inputField in FindObjectsOfType<InputField>())
                texts.Add(inputField.text);
            
            UserData data = new UserData(texts);
            
            SaveSystem.SaveUser(data);
        }
        
        [ContextMenu("Load")]
        public void LoadPlan()
        {
            UserData data = SaveSystem.LoadUser();
            InputField[] fields = FindObjectsOfType<InputField>();
            for (var i = 0; i < fields.Length; i++)
                fields[i].text = data.values[i];
        }
    }
