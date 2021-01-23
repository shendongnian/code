        /// <summary>
        /// Extension method to select item from comboxbox
        /// </summary>
        /// <param name="comboBox">Combobox Element</param>
        /// <param name="item">Item to select</param>
        /// <returns></returns>
        public static bool SelectComboboxItem(this AutomationElement comboBox, string item)
        {
            if (comboBox == null) return false;
            // Get the list box within the combobox
            AutomationElement listBox = comboBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List));
            if (listBox == null) return false;
            // Search for item within the listbox
            AutomationElement listItem = listBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, item));
            if (listItem == null) return false;
            // Check if listbox item has SelectionItemPattern
            object objPattern;
            if (true == listItem.TryGetCurrentPattern(SelectionItemPatternIdentifiers.Pattern, out objPattern))
            {
                SelectionItemPattern selectionItemPattern = objPattern as SelectionItemPattern;
                selectionItemPattern.Select(); // Invoke Selection
                return true;
            }
            return false;
        }
