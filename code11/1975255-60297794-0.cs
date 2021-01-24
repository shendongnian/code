    private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            XlMousePointer originalCursor = Globals.ThisAddIn.Application.Cursor;
            Globals.ThisAddIn.Application.Cursor = XlMousePointer.xlWait;
            Method1();
            Globals.ThisAddIn.Application.Cursor = originalCursor;
        }
