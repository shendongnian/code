    protected override void OnMouseDown(MouseEventArgs e) {
      base.OnMouseDown(e);
      if (e.Button == MouseButtons.Left) {
        if (e.Clicks > 1) {
          // do something with double-click
        } else {
          ReleaseCapture();
          SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
      }
    }
