     void SetControlText(Type controlType, string controlName, string text) {
          foreach (var ctl in this.Controls.OfType<Control>()) {
            if (ctl.GetType() == controlType && ctl.Name == controlName) {
              ctl.Text = text;
              break;
            }
          }
        }
