    private static System.Windows.Forms.ErrorProvider GetErrorProvider(System.Windows.Forms.Control control)
    {
        //get the containing form of the control
        var form = control.GetContainerControl();
        //use reflection to get to "components" field
        var componentField = form.GetType().GetField("components", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (componentField != null)
        {
            //get the component collection from field
            var components = componentField.GetValue(form);
            //locate the ErrorProvider within the collection
            return (components as System.ComponentModel.IContainer).Components.OfType<System.Windows.Forms.ErrorProvider>().FirstOrDefault();
        }
        else
        {
            return null;
        }
    }
