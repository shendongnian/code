    using SimpleJSON;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class DropDownController : MonoBehaviour
    {
        [Header("Components References")]
        public Dropdown dropdown;
    
        [Header("Input")]
        // Whereever you get the json from
        public string JsonString = "{\"USULAN_ID\":\"some id\", \"USULAN_LAT\":\"some lat\", \"USULAN_LONG\":\"some long\", \"USULAN_URGENSI\":\"some urgensi\"}";
    
        [Header("Output")]
        public string currentlySelectedKey;
        public string currentlySelectedValue;
    
        private Dictionary<string, string> entries = new Dictionary<string, string>();
        private List<string> keys = new List<string>();
    
        private void Awake()
        {
            if (!dropdown) dropdown = GetComponent<Dropdown>();
    
            dropdown.onValueChanged.AddListener(HandleValueChanged);
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
            var dropdownOptions = new List<Dropdown.OptionData>();
            keys.Clear();
            entries.Clear();
    
            // JSONNode implements an Enumerator letting
            // us simply iterate through all first level entries
            foreach (var field in json)
            {
                // simply assume string keys and string values
                // might brake if the provided json has another structure
                // I'll skip the null checks here
                entries.Add(field.Key, field.Value);
                keys.Add(field.Key);
                dropdownOptions.Add(new Dropdown.OptionData(field.Key));
            }
    
            dropdown.options = dropdownOptions;
    
            // set default
            dropdown.value = 0;
            HandleValueChanged(0);
        }
    
        private void HandleValueChanged(int newValue)
        {
            currentlySelectedKey = keys[newValue];
            currentlySelectedValue = entries[currentlySelectedKey];
        }
    }
