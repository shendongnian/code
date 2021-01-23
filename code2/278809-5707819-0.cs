    if (e.Row.Cells[2].Text.Contains(")")) {
      e.Row.Cells[2].BackColor = System.Drawing.Color.Red;
    } else {
      e.Row.Cells[2].BackColor = System.Drawing.Color.Green;
    }
