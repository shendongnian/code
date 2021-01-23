    /// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
    /// <param term='commandName'>The name of the command to execute.</param>
    /// <param term='executeOption'>Describes how the command should be run.</param>
    /// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
    /// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
    /// <param term='handled'>Informs the caller if the command was handled or not.</param>
    /// <seealso class='Exec' />
    public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
    {
        object tempObject = null;   // It's required but I'm not sure what one can do with it...
        Windows2 windows2 = null;   // Reference to the window collection displayed in the application host.
        Assembly asm = null;        // The assembly containing the user control.
        Window myWindow = null;     // Will contain the reference of the new Tool Window.
    
        try
        {
            handled = false;
    
            if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
            {
                if (commandName == "MyAddin1.Connect.MyAddin1")
                {
                    handled = true;
    
                    // Get a reference to the window collection displayed in the application host.
                    windows2 = (Windows2)_applicationObject.Windows;
    
                    // Get the executing assembly.
                    asm = Assembly.GetExecutingAssembly();
                    
                    // Create the tool window and insert the user control.
                    myWindow = windows2.CreateToolWindow2(_addInInstance, asm.Location, "MyAddin1.MyForm", "My Tool Window", "{CB2AE2BD-2336-4615-B0A3-C55B9C7794C9}", myform);
                    
                    // Set window properties to make it act more like a modless form.
                    myWindow.Linkable = false;  // Indicates whether the window can be docked with other windows in the IDE or not.
                    myWindow.IsFloating = true; // Indicates whether the window floats over other windows or not.
                    
                    // Show the window.
                    myWindow.Visible = true;
    
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
