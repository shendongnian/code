    private void Export()
    {
      // Do UI check first
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = "Excel Documents (*.xls)|*.xls";
      sfd.FileName = "Export.xls";
        
      // If failed , early return
      if (sfd.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      ProgressWindow prg = new ProgressWindow();
      prg.Show();
      // Do your copy and export code below, you may use task or thread if you don't want to let current form unresponsive.
      operation();
      // After finished, close your progress window
      prg.Close();
    }
    void operation()
    {
         // Copy DataGridView results to clipboard
         CopyAllToClipBoard();
         object misValue = System.Reflection.Missing.Value;
         Excel.Application xlexcel = new Excel.Application();
         // Without this you will get two confirm overwrite prompts
         xlexcel.DisplayAlerts = false;
         Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
         Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
         // Paste clipboard results to worksheet range
         Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
         CR.Select();
         xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
         // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
         // Delete blank column A and select cell A1
         //Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
         //delRng.Delete(Type.Missing);
         //xlWorkSheet.get_Range("A1").Select();
         // Save the excel file under the captured location from the SaveFileDialog
         xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
         xlexcel.DisplayAlerts = true;
         xlWorkBook.Close(true, misValue, misValue);
         xlexcel.Quit();
         releaseObject(xlWorkSheet);
         releaseObject(xlWorkBook);
         releaseObject(xlexcel);
         // Clear Clipboard and DataGridView selection
         Clipboard.Clear();
         dgvSearchFilter.ClearSelection();
         // Open the newly saved excel file
         if (File.Exists(sfd.FileName))
             System.Diagnostics.Process.Start(sfd.FileName);
    }
