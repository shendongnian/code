    using System.Windows.Forms;
    public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst,
     ref System.Array custom)
    {
        _applicationObject = (DTE2)application;
        _addInInstance = (AddIn)addInInst;
        // Pass the applicationObject member variable to the code example.
        SolutionExample((DTE2)_applicationObject);
    }
    
    public void SolutionExample(DTE2 dte)
    {
        // This function creates a solution and adds a Visual C# Console
        // project to it.
        try{
            Solution3 soln = (Solution3)_applicationObject.Solution;
            String csTemplatePath;
            // The file path must exist on your computer.
            // Replace <file path> below with an actual path.
            String csPrjPath = "<file path>";
            "<file path>MessageBox.Show("Starting...");
            "<file path>"<file path>csTemplatePath = 
              soln.GetProjectTemplate("ConsoleApplication.zip", "CSharp");
            // Create a new C# Console project using the template obtained 
            // above.
            soln.AddFromTemplate(csTemplatePath, csPrjPath,
              "New CSharp Console Project", false);
            MessageBox.Show("Done!");
        }
        catch(SystemException ex)
        {
            MessageBox.Show("ERROR: " + ex);
        }
    }
