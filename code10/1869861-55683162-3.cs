    [RequireComponent(typeof(InputField))]
    public class InputValidator : MonoBehaviour
    {
        // Here reference the according Button
        // Via the Inspector or script
        public Button targetButton;
        // As little bonus if you want here reference an info box why the input is invalid
        public GameObject infoBox;
        private InputField inputField;
        private void Awake()
        {
            inputField = GetComponent<InputField>();
            // Add callback
            inputField.onValueChanged.AddListener(ValidateInput);
        }
        // Additionally validate the input value everytime 
        // The InputField (this component to be exact) gets enabled in the scene
        private void OnEnable()
        {
            ValidateInput(inputField.text);
        }
        private void ValidateInput(string input)
        {
            // Here you could implement some replace or further validation logic
            // if e.g. only certain characters shall be allowed
            // Enable the button only if some valid input is available
            targetButton.interactable = !string.IsNullOrWhiteSpace(input);
            // just a bonus if you want to show an info box why input is invalid
            if (infoBox) infoBox.SetActive(string.IsNullOrWhiteSpace(input));
        }
    }
