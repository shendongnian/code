    private static void ControlSaveDialog(System.Windows.Automation.AutomationElement mainWindow, string path)
    {
        //obtain the save as dialog
        var saveAsDialog = mainWindow
                            .FindFirst(TreeScope.Descendants,
                                       new PropertyCondition(AutomationElement.NameProperty, "Save As"));
        //get the file name box
        var saveAsText = saveAsDialog
                .FindFirst(TreeScope.Descendants,
                           new AndCondition(
                               new PropertyCondition(AutomationElement.NameProperty, "File name:"),
                               new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)))
                .GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
        //fill the filename box 
        saveAsText.SetValue(path);
        Thread.Sleep(1000);
        //find the save button
        var saveButton =
                saveAsDialog.FindFirst(TreeScope.Descendants,
                new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, "Save"),
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)));
        //invoke the button
        var pattern = saveButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        pattern.Invoke();
    }
