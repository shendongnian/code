    [RequireComponent(typeof(InputField))]
    public class InputValidator : MonoBehaviour
    {
        // Here reference the according Button
        // Via the Inspector or script
        public Button targetButton;
        private InputField inputField;
        private void Awake()
        {
            inputField = GetComponent<InputField>();
            
            // Add callback
            InputField.onValidateInput += (input, index, char) => { return OnValidateInput(input, index, char); };
        }
        // Additionally validate the input value everytime 
        // The InputField (this component to be exact) gets enabled in the scene
        private void OnEnable()
        {
            OnValidateInput(inputField.text, inputField.text.Length, inputFied.text[InputField.text.Length - 1]);
        }
        private void OnValidateInput(string input, int currentIndex, Char addedChar)
        {
            // Here you could implement some replace or further validation logic
            // if e.g. only certain characters shall be allowed
            // Enable the button only if some valid input is available
            targetButton.interactable = !string.IsNullOrWhitespace(input);         
        }
    }
