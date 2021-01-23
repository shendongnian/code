    private Microsoft.Office.Core.IRibbonExtensibility ribbonObj;
    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
    {
     ribbonObj = new Ribbon1(this);
     return ribbonObj;
    }
    
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    { 
     // Calling the public method TEST() in Ribbon1.cs 
     //MyNameSpace is the namespace used in your project ie., your project name 
     ((MyNameSpace.Ribbon1)ribbonObj).TEST();
     // Calling the public variable flag in Ribbon1.cs  
     ((MyNameSpace.Ribbon1)ribbonObj).flag;
    }
