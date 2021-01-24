    public partial class Ribbon1
        {
            private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
            {
    
            }
    
            private void callVBA_Click(object sender, RibbonControlEventArgs e)
            {
                if (Globals.ThisAddIn.Application.ActiveWorkbook.Name == "VBA.xlsm")
                {
                    Globals.ThisAddIn.Application.Workbooks["VBA.xlsm"].Application.Run("Foo");
                }
            }
        }
