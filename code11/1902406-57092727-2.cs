    public class GetTextFromInputField : MonoBehaviour {
       public InputField InputName;
       public Text GottenText;
       private string _textFromInputField;
       public void GetTextFromInputField() {
           _textFromInputField = InputName.text;
           GottenText.text = _textFromInputField;
       }
    }
