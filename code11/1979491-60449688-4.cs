    // Make TextBox to look like a label: readonly, color, border etc.
    private static void ToLabelMode(TextBox box) {
      if (null == box)
        return;
      box.HideSelection = true;
      box.BackColor = SystemColors.Control;
      box.ReadOnly = true;
      box.BorderStyle = BorderStyle.None;
    }
    private static void ToTextBoxMode(TextBox box) {
      if (null == box)
        return;
      box.HideSelection = false;
      box.BackColor = SystemColors.Window;
      box.ReadOnly = false;
      box.BorderStyle = BorderStyle.Fixed3D;
    }
