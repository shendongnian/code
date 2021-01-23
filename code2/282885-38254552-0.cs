    public static bool SelectComboboxItem(this AutomationElement comboBox, string item)
        {
            AutomationElement listBox = comboBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List));
            if (listBox == null) return false;
            AutomationElement listItem = listBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, item));
            if (listItem == null) return false;
            object objPattern;
            if (true == listItem.TryGetCurrentPattern(SelectionItemPatternIdentifiers.Pattern, out objPattern))
            {
                SelectionItemPattern selectionItemPattern = objPattern as SelectionItemPattern;
                selectionItemPattern.Select();
                return true;
            }
            return false;
        }
