               MainForm mainForm = new MainForm();
               Automation.AddAutomationEventHandler(
               WindowPattern.WindowOpenedEvent, AutomationElement.RootElement,
               TreeScope.Subtree, (uiElm, evt) =>
               {
                   AutomationElement element = uiElm as AutomationElement;
                   if (element == null) return;
                   try
                   {
                       if (element.Current.ProcessId == Process.GetCurrentProcess().Id)
                       {
                           IntPtr elmHandle = (IntPtr)element.Current.NativeWindowHandle;
                           Form form = Application.OpenForms.OfType<Form>()
                               .Where(f => (f.AccessibilityObject as Control.ControlAccessibleObject).Handle == elmHandle)
                               .FirstOrDefault();
                           mainForm.UpdateTabFormsDict(form); // adding a open form to the current tab
                       }
                   }
                   catch (ElementNotAvailableException)
                   { /* May happen when Debugging => ignore or log */
                   }
               });
