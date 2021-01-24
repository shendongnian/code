    private void Form_MouseMove(object sender, MouseEventArgs e) {
      if (magicTextBox.Bounds.Contains(e.Location) && !magicTextBox.Visible) {
        //Do something...
     }
    }
