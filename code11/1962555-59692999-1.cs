    [Serializable]
    public class UserData
    {
        public List<string> inputFieldText = new List<string>();
        public UserData ()
        {
            foreach (InputField inputField in GameObject.FindObjectsOfType<InputField>())
                inputFieldText.Add(inputField.text);
        }
    }
