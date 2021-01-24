        private void ThisDocument_BeforeSave(object sender, object e)
        {
            //Suppress the built-in SaveAs interface (dialog box)
            e.SaveAsUi = false;
            //Cancel the default action
            e.Cancel = true;
            Word.Dialog dlg = wdApplication.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFileSaveAs];
            //Word dialog box parameters have to be accessed via Late-Binding (PInvoke) 
            //To get the path, use the Name property
            object oDlg = (object)dlg;
            object[] oArgs = new object[1];
            oArgs[0] = (object)@"";
            dlg.Show(ref missing);
            object fileName = oDlg.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, oDlg, oArgs);
        }
