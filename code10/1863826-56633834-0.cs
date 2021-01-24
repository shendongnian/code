    private void SearchRTF(string mytext) {
      var result = myRichEditControl.Document.StartSearch(mytext);
      if (result.FindNext()) {
        var cp = myRichEditControl.Document.BeginUpdateCharacters(result.CurrentResult);
        cp.ForeColor = System.Drawing.Color.White;
        cp.BackColor = System.Drawing.Color.Blue;
        myRichEditControl.Document.EndUpdateCharacters(cp);
      }
    }
