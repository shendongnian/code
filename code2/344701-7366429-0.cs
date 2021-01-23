              string s;
              foreach (Control cc in this.Controls)
              {
                  if (cc is ComboBox || cc is TextBox)
                  {
                      if (string.IsNullOrEmpty(cc.Text))
                      {
                          s = cc.Text;
                          //Do something with the value
                      }
                  }
            
