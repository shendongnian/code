        // Summary:
        //     Select the option by the index, as determined by the "index" attribute of
        //     the element.
        //
        // Parameters:
        //   index:
        //     The value of the index attribute of the option to be selected.
        public void SelectByIndex(int index);
        
        // Summary:
        //     Select all options by the text displayed.
        //
        // Parameters:
        //   text:
        //     The text of the option to be selected. If an exact match is not found, this
        //     method will perform a substring match.
        // Remarks:
        //     When given "Bar" this method would select an option like:
        //     <option value="foo">Bar</option>
        public void SelectByText(string text);
        // Summary:
        //     Select an option by the value.
        //
        // Parameters:
        //   value:
        //     The value of the option to be selected.
        // Remarks:
        //     When given "foo" this method will select an option like:
        //     <option value="foo">Bar</option>
        public void SelectByValue(string value);
