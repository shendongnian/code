    public string ZTest(string contentBoxText) {
      string retValue = null;
      string filename = contentBoxText;
      if (File.Exists(filename)) {
        using (StreamReader fileReader = new StreamReader(filename)) {
          string fileRow;
          while ((fileRow = fileReader.ReadLine()) != null) {
            string[] fileDataField = fileRow.Split(new string[] { "\r\n\t", " " }, StringSplitOptions.RemoveEmptyEntries);
            string ListSplitLineByLine = "";
            foreach (string lineByLine in fileDataField) {
              ListSplitLineByLine += "\r\n" + lineByLine;
            }
            if (!String.IsNullOrEmpty(ListSplitLineByLine)) {
              retValue = ListSplitLineByLine.Trim();
              GenCombItems();
            } else {
              MessageBox.Show("No data");
            }
          }
          // Line below is not necessary. Handled by the "using" clause.
          // fileReader.Close();
        }
      } else {
        MessageBox.Show("File Not Found");
      }
      return retValue;
    }
