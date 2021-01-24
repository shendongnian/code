    public class Homepage : MonoBehaviour
    {
        // This still allows to reference the object in the Inspector 
        // but prevents direct access from other scripts
        [SerializeField] private InputField ipField;
    
        // This is a public ReadOnly property for reading the IP from other scripts
        public string IP => ipField.text;
    
        ...
    }
