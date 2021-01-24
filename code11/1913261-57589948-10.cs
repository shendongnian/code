    using SimpleJSON;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class DropDownController : MonoBehaviour
    {
        [Header("Components References")]
        public Dropdown dropdown;
    
        [Header("Input")]
        // Where ever you get the json data from
        public string JsonString = "{\"USULAN_ID\":\"some id\", \"USULAN_LAT\":\"some lat\", \"USULAN_LONG\":\"some long\", \"USULAN_URGENSI\":\"some urgensi\"}";
    
        [Header("Output")]
        public string currentlySelectedKey;
        public string currentlySelectedValue;
        public Text selectedValueText;
    
        private Dictionary<string, string> entries = new Dictionary<string, string>();
    
        private void Awake()
        {
            // get the component
            if (!dropdown) dropdown = GetComponent<Dropdown>();
    
            // register a callback 
            dropdown.onValueChanged.AddListener(HandleValueChanged);
            // where ever you need to call this method
            UpdateOptions(JsonString);
        }
    
        public void UpdateOptions(string jsonString)
        {
            // parse the string to a JSONNode
            var json = JSON.Parse(jsonString);
            // unfortunately SimpleJson simply returns null
            // and doesn't throw any exceptions so you have to do it on your own
            if(json == null)
            {
                Debug.LogFormat(this, "Oh no! Something went wrong! Can't parse json: {0}", jsonString);
                return;
            }
    
            // for the case this is called multiple times
            // reset the lists and dictionaries
            dropdown.options.Clear();
            entries.Clear();
            //optional add a default field
            entries.Add("Please select a field", "no field selected!");
            dropdown.options.Add(new Dropdown.OptionData("Please select a field"));
    
            // JSONNode implements an Enumerator letting
            // us simply iterate through all first level entries
            foreach (var field in json)
            {
                // simply assume string keys and string values
                // might brake if the provided json has another structure
                // I'll skip the null checks here
                var key = field.key;
                var value = field.value;
                entries.Add(key, value);
                dropdown.options.Add(new Dropdown.OptionData(key));
            }
    
            // set default
            dropdown.value = 0;
            HandleValueChanged(0);
        }
    
        private void HandleValueChanged(int newValue)
        {
            currentlySelectedKey = dropdown.options[newValue].text;
            currentlySelectedValue = entries[currentlySelectedKey];
            // optional visual feedback for the user
            selectedValueText.text = currentlySelectedValue;
            // optional color feedback for not yet selected
            selectedValueText.color = newValue == 0 ? Color.red : Color.black;
        }
    }
