        private void ReplaceText(string textToInsert)
        {
            // https://docs.microsoft.com/en-us/visualstudio/vsto/how-to-programmatically-exclude-paragraph-marks-when-creating-ranges?view=vs-2019
            Microsoft.Office.Interop.Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
            // if current selection has a trailing paragraph mark, then 
            // modify the selection to omit it before replacing the text
            if (currentSelection.Range.Text.Substring(currentSelection.Range.Text.Length-1, 1).Equals("\r"))
            {
                object charUnit = Microsoft.Office.Interop.Word.WdUnits.wdCharacter;
                object move = -1;
                currentSelection.MoveEnd(ref charUnit, ref move);
            }
            currentSelection.Range.Text = textToInsert;
        }
