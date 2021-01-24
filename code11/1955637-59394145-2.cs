    // Create a label on this
    infoLabel = new Label() {
      AutoSize  = true,
      Location  = new System.Drawing.Point(200, 10),
      Size      = new System.Drawing.Size(35, 13),
      BackColor = System.Drawing.SystemColors.Control,
      Font      = new System.Drawing.Font("Arial", 13),
      ForeColor = System.Drawing.Color.Black,
      TabIndex  = 1,
      Text      = "this is info",
      Parent    = this // <- instead of this.Controls.Add(infoLabel);
    };
    
    // make it topmost
    infoLabel.BringToFront();
