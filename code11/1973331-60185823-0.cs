    using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.UI;
        public class DropdownFilter : MonoBehaviour
        {
            [SerializeField]
            private InputField inputField;
    
        [SerializeField]
        private Dropdown dropdown;
    
        private List<Dropdown.OptionData> dropdownOptions;
    
        private void Start()
        {
            dropdownOptions = dropdown.options;
        }
        public void FilterDropdown(string input)
        {
            dropdown.options = dropdownOptions.FindAll(option => option.text.IndexOf(input) >= 0);
        }
    }
