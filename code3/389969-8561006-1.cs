          private void ("what tab is benig pressed on")_KeyPress(object sender,    KeyPressEventArgs e)
          {
             if (e.Keychars == keys.Tab)
              {
                webBrowser.Select();
                webBrowser.Focus();
              }
            
          }
