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
            inputField.onValidateInput += (input, index, character) => { return OnValidateInput(input, index, character); };
        }
        // Additionally validate the input value everytime 
        // The InputField (this component to be exact) gets enabled in the scene
        private void OnEnable()
        {
            OnValidateInput(inputField.text, inputField.text.Length, inputField.text[inputField.text.Length - 1]);
        }
        private char OnValidateInput(string input, int currentIndex, char addedChar)
        {
            // Here you could implement some replace or further validation logic
            // if e.g. only certain characters shall be allowed
            // Enable the button only if some valid input is available
            targetButton.interactable = !string.IsNullOrWhiteSpace(input);
            return addedChar;
        }
    }
