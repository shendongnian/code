    public class GetTextFromInputField : MonoBehaviour {
       public InputField InputName;
       public Text GottenText;
       private string _textFromInputField;
       public void GetTextFromInputField() {
           //getting the InputName objects Text gameobject's Transform and then hook it's Text component and text property
           _textFromInputField = InputName.transform.GetChild(2).GetComponent<Text>().text;
           GottenText.text = _textFromInputField;
       }
    }
