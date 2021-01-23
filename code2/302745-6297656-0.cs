      public bool TextBox_Validation(string sender)
      {
          try
          {
              if (string.IsNullOrEmpty(sender))
              {
                  MessageBox.Show("Please enter a value");
                  return false;
              }
              else
                  return true;
          }
          catch(Exception ex)
          {
              MessageBox.Show(ex.Message);
              return false;
          }
      }
