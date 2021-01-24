    public class findFrame : MonoBehaviour
    { 
        public InputField searchText;
    
        // A HashSet is basically a list but makes sure every element is unique
        // I would make this rather a Dictionary<string, GameObject> in case
        // you also plan to access a specific button by name
        // otherwise a HashSet does it
        private HashSet<GameObject> childButtons = new HashSet<GameObject>();
    
        public void Awake()
        {
            //Adds a listener to the input field and invokes a method when the value changes.
            searchText.onValueChanged.AddListener(OnValueChanged);
    
            // Run through all children GameObjects of this GameObject and check the tag
            foreach(Transform child in transform)
            // or as said if possible/necessary for nested children you could use
            //foreach(var child in GetComponentsInChildren<Button>())
            {
                // check if this child has the correct tag
                if(!child.CompareTag("Button")) continue;
    
                // If the tag matches add it to the HashSet
                childButtons.Add(child.gameObject);
            }
        }
    
        // Invoked when the value of the text field changes.
        public void OnValueChanged()
        {
            Debug.Log("Value Changed");
    
            // Get the search value
            var searchString = searchTexxt.text;
    
            // Simply run through the HashSet and set the matching object(s) active, the others inactive
            foreach(var button in childButtons)
            {
                var name = button.name;
    
                // Here you can either check for an exact match
                //var isMatch = name.Equals(searchString, COMPARISONTYPE);
                // Or you could also check for partial matches - I would prefer this
                // (required if you want to see objects also while the user didn't type out the full name yet)
                // either by simply using Contains
                //var isMatch = name.Contains(searchString);
                // or if you need it more customized 
                var isMatch = string.Compare(name, searchString, COMPARISONTYPE) == 0;
    
                button.SetActive(isMatch);
                if(isMatch) Debug.Log($"Found match for {searchString} in button ${name} ");
            }
        }
    }
    
