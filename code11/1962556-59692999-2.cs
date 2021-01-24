    public class FieldController : MonoBehaviour
    {
        [ContextMenu("Save")]
        public void SavePlan()
        {
            SaveSystem.SaveUser();
        }
        
        [ContextMenu("Load")]
        public void LoadPlan()
        {
            UserData data = SaveSystem.LoadData();
            foreach (InputField inputField in FindObjectsOfType<InputField>())
                inputField.text = data.inputFieldText[0];
        }
    }
