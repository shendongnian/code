    var all = appWindow.GetElement(SearchCriteria.ByControlType(ControlType.ComboBox)
    .AndByText(parentValue));
     var element = all.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, childValue));
                    TextBox textBox = new TextBox(all, appWindow.ActionListener);
    
     TestStack.White.InputDevices.AttachedKeyboard keyboard = appWindow.Keyboard;
                    textBox .Click();
                    keyboard.Enter("test");
