        Word.Application wdApp = null; //class level member
      private void btnRunningWordTable_Click(object sender, EventArgs e)
        {
            getWordInstance();
            Word.Document doc = wdApp.ActiveDocument;
            //Debug.Print(wdApp.ActiveDocument.FullName);
            Word.Table tbl = null;
            Word.Range rng = doc.Content;
            if (doc.Tables.Count > 0)
            {
                tbl = doc.Tables[1];
            }
            else
            {
                //Make sure to not replace existing content - put the table at the end
                rng.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
                tbl = doc.Tables.Add(rng, 3, 3, Word.WdDefaultTableBehavior.wdWord8TableBehavior, ref missing);
            }
            if (tbl != null)
            {
                Debug.Print(tbl.Rows.Count.ToString());
            }
        }
        internal void getWordInstance()
        {
            try
            {
                if (wdApp == null)
                {
                    Process[] wdPcs = Process.GetProcessesByName("WinWord");
                    int nrWordInstances = wdPcs.Length - 1;
                    if (nrWordInstances >= 0)
                    {
                        //Picks up other running instance, not new one
                        wdApp = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                    }
                    else
                        wdApp = new Word.Application();
                }
                wdApp.Visible = true;
                wdApp.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
