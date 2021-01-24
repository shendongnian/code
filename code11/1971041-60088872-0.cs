    public class findFrame : MonoBehaviour
    { 
        public InputField searchText;
    
        private Dictionary<string, GameObject> childButtons = new Dictionary<string, GameObject>();
    
        public void Awake()
        {
            //Adds a listener to the input field and invokes a method when the value changes.
            searchText.onValueChanged.AddListener(OnValueChanged);
    
            // Run through all children GameObjects of this GameObject and check the tag
            foreach(Transform child in transform)
            {
                if(!child.CompareTag("Button")) continue;
    
                // Of the tag matches add it to the dictionary
                if(!childButtons.Contains(child.name)) childButtons.Add(child.name, child.gameObject);
            }
        }
    
        // Invoked when the value of the text field changes.
        public void OnValueChanged()
        {
            Debug.Log("Value Changed");
    
            var searchString = searchTexxt.text;
    
            // Simply run through the dictionary and set the matching object active
            foreach(var kvp in childButtons)
            {
                var name = kvp.Key;
                var button = kvp.Value;
    
                // Here you can either check for an exact match
                var isMatch = name.Equals(searchString, ComparisonType);
                // Or you could also check for partial matches 
                // (required if you want to see objects also while the user didn't type out the full name yet)
                //var isMatch = name.Contains(searchString, ComparisonType);
    
                button.SetActive(isMatch);
                if(isMatch) Debug.Log($"Found match for {searchString} in button ${name} ");
            }
        }
    }
    
