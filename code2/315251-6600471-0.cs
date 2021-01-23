    // in the Page_Load or whereever you generate the textboxes to begin
    var boxes = new List<TextBox>();
    for (int i = 0; i < numRecords /* number of boxes */; i++) {
      var newBox = new TextBox();
      // set properties here
      
      boxes.Add(newBox);
      this.Controls.Add(newBox);
    }
