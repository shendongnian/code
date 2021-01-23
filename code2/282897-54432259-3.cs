    <pre>
      public static void SetComboBox(AutomationElement ComboxBox, string SelectedValue)
            {
                AutomationElement ListBox = ComboxBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "ListBox"));
                AutomationElement SelectedItem = ListBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, SelectedValue));
                ((SelectionItemPattern)SelectedItem.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
            }
   
