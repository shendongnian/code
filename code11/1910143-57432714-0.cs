    Protected override void OnGotFocus(EventArgs e) {
              base.OnGotFocus(e);
              If (!selectionSet) {
                  // We get one shot at selecting when we first get focus.  If we don't
                  // do it, we still want to act Like the selection was set.
                  selectionSet = true;
     
                  // If the user didn't provide a selection, force one in.
                  If (SelectionLength == 0 && Control.MouseButtons == MouseButtons.None) {
                      SelectAll();
                  }
              }
