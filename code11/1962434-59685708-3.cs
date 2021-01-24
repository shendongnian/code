        public bool setVisbility(Office.IRibbonControl control)
        {
            int nWorkbooks = Globals.ThisAddIn.Application.Workbooks.Count;
            if (nWorkbooks == 0)
            {
                return false;
            }
            if (Globals.ThisAddIn.Application.ActiveWorkbook != null &&
            Globals.ThisAddIn.Application.ActiveWorkbook.Name == "Template.xlsm")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
