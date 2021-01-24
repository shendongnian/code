c#
 public partial class Ribbon1
    {
        private bool vbaMacroFound;
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            CheckButtons();
            Globals.ThisAddIn.Application.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler(Workbook_Activate);
        }
        private void callVBA_Click(object sender, RibbonControlEventArgs e)
        {
            if (vbaMacroFound)
            {
                Globals.ThisAddIn.Application.Workbooks["VBA.xlsm"].Application.Run("Foo");
            }
        }
        private void Workbook_Activate(Excel.Workbook Wb)
        {
            CheckButtons();
        }
        private void CheckButtons()
        {
            vbaMacroFound = false;
            this.callVBA.Enabled = false;
            this.callVBA.ScreenTip = "There is no specified macro in none of active workbooks";
            foreach (Excel.Workbook book in Globals.ThisAddIn.Application.Workbooks)
            {
                if (book.Name.Equals("VBA.xlsm"))
                {
                    this.callVBA.Enabled = true;
                    this.callVBA.ScreenTip = "Call the sub from VBA";
                    vbaMacroFound = true;
                }
            }
        }
    }
  [1]: https://i.stack.imgur.com/CUbbt.gif
