    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WatiN.Core;
    using WatiN.Core.Native.Windows;
    using System.Threading;
    using System.Windows.Automation;
    
    namespace MyProject
    {
        public static class BrowserExtensionMethods
        {
            public static void DownloadIeFile(this IE browser,string saveAsFilename=null)
            {
                // see information here (http://msdn.microsoft.com/en-us/library/windows/desktop/ms633515(v=vs.85).aspx)
                Window windowMain = new Window(NativeMethods.GetWindow(browser.hWnd, 5));
                TreeWalker dialogElementTreeWalker = new TreeWalker(Condition.TrueCondition);
                AutomationElement mainWindow = dialogElementTreeWalker.GetParent(AutomationElement.FromHandle(browser.hWnd));
    
                Window windowDialog = new Window(NativeMethods.GetWindow(windowMain.Hwnd, 5));
                // if doesn't work try to increase sleep interval or write your own waitUntill method
                Thread.Sleep(1000);
                windowDialog.SetActivate();
                AutomationElementCollection dialogElements = AutomationElement.FromHandle(windowDialog.Hwnd).FindAll(TreeScope.Children, Condition.TrueCondition);
    
                if (string.IsNullOrEmpty(saveAsFilename))
                {
                    ClickSave(dialogElements);
                }
                else
                {
                    ClickSaveAs(mainWindow, dialogElements,saveAsFilename);
                }
            }
    
            private static void ClickSaveAs(AutomationElement mainWindow, AutomationElementCollection dialogElements,string filename)
            {
                foreach (AutomationElement element in dialogElements)
                {
    
                    if (element.Current.Name.Equals("Save"))
                    {
                        AutomationElementCollection dialogSubElements = element.FindAll(TreeScope.Children, Automation.ControlViewCondition);
                        InvokePattern clickPatternForSaveDropdown = (InvokePattern)dialogSubElements[0].GetCurrentPattern(AutomationPattern.LookupById(10000));
                        clickPatternForSaveDropdown.Invoke();
                        Thread.Sleep(3000);
    
                        AutomationElementCollection dialogElementsInMainWindow = mainWindow.FindAll(TreeScope.Children, Condition.TrueCondition);
                        foreach (AutomationElement currentMainWindowDialogElement in dialogElementsInMainWindow)
                        {
                            if (currentMainWindowDialogElement.Current.LocalizedControlType == "menu")
                            {
                                // first array element 'Save', second array element 'Save as', third second array element    'Save and open'
                                InvokePattern clickMenu = (InvokePattern)currentMainWindowDialogElement.FindAll(TreeScope.Children, Condition.TrueCondition)[1].GetCurrentPattern(AutomationPattern.LookupById(10000));
                                clickMenu.Invoke();
                                Thread.Sleep(5000);
                                ControlSaveDialog(mainWindow, filename);
                                break;
    
                            }
                        }
                    }
                }
            }
    
            private static void ClickSave(AutomationElementCollection dialogElements)
            {
                foreach (AutomationElement element in dialogElements)
                {
                    // You can use "Save ", "Open", ''Cancel', or "Close" to find necessary button Or write your own enum
                    if (element.Current.Name.Equals("Save"))
                    {
                        // if doesn't work try to increase sleep interval or write your own waitUntil method
                        // WaitUntilButtonExsist(element,100);
                        Thread.Sleep(1000);
                        AutomationPattern[] automationPatterns = element.GetSupportedPatterns();
                        // replace this foreach if you need 'Save as' with code bellow
                        foreach (AutomationPattern currentPattern in automationPatterns)
                        {
                            // '10000' button click event id 
                            if (currentPattern.Id == 10000)
                            {
                                InvokePattern click = (InvokePattern)element.GetCurrentPattern(currentPattern);
                                click.Invoke();
                            }
                        }
                    }
                }
            }
    
            private static void ControlSaveDialog(AutomationElement mainWindow, string path)
            {
                //obtain the save as dialog
                //*** must disable throwing of the NonComVisibleBaseClass "exception" for this to work in debug mode:
                //              1. Navigate to Debug->Exceptions...
                //              2. Expand "Managed Debugging Assistants"
                //              3. Uncheck the NonComVisibleBaseClass Thrown option.
                //              4. Click [Ok]
                //***copied from http://social.msdn.microsoft.com/Forums/en-US/27c3bae8-41fe-4db4-8022-e27d333f714e/noncomvisiblebaseclass-was-detected?forum=Vsexpressvb
    
                var saveAsDialog = mainWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Save As"));
                //var saveAsDialog = mainWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "[#] Save As [#]"));  //needed if using sandboxie
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
        }
    }
