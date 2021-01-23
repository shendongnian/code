        protected override Microsoft.Office.Core.IRibbonExtensibility
        CreateRibbonExtensibilityObject()
        {
             return new Microsoft.Office.Tools.Ribbon.RibbonManager(
             new Microsoft.Office.Tools.Ribbon.OfficeRibbon[] { new       
                SharedRibbonLibrary.Ribbon1() });
     
        }
 
