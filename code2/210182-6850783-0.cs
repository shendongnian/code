    TextBox TaskPane;
    void DragNDrop(object sender, DragEventArgs e) {
      if (e.Effect == DragDropEffects.Move) {
        if (e.Data.GetDataPresent(DataFormats.CommaSeparatedValue)) {
          string csvText = e.Data.GetData(DataFormats.CommaSeparatedValue, false).ToString();
          if (!String.IsNullOrEmpty(csvText)) {
            TaskPane.Text = csvText;
          }
        }
      }
    }
    void DragOver(object sender, DragEventArgs e) {
      if (!e.Data.GetDataPresent(DataFormats.CommaSeparatedValue)) {
        e.Effect = DragDropEffects.None;
      } else {
        e.Effect = DragDropEffects.Move;
      }
    }
