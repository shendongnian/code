    public static void SelectValueInComboBox(string comboBox, string value)
                {
                    var comboBoxElement = HelperMethods.FindElementFromAutomationID(comboBox);
                    if (comboBoxElement == null)
                        throw new Exception("Combo Box not found");
               
                    ExpandCollapsePattern expandPattern = (ExpandCollapsePattern)comboBoxElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
    
                    AutomationElement comboboxItem = comboBoxElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, value));
        
                    SelectionItemPattern selectPattern = (SelectionItemPattern)comboboxItem.GetCurrentPattern(SelectionItemPattern.Pattern);
                    selectPattern.Select();
                }
  
          
