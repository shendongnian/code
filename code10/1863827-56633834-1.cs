    private void SearchRTF(string mytext) {
      var result = myRichEditControl.Document.StartSearch(mytext);
      if (result.FindNext()) {
        var section = myRichEditControl.Document.BeginUpdateCharacters(result.CurrentResult);
        section.ForeColor = System.Drawing.Color.White;
        section.BackColor = System.Drawing.Color.Blue;
        myRichEditControl.Document.EndUpdateCharacters(section);
      }
    }
