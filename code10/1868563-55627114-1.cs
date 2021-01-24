    private void button1_Click(object sender, EventArgs e) { 
      bool isValid = true;
      foreach( var control in this.Controls)
       {
          if (string.IsNullOrEmpty(control.Text)) 
          { 
              isValid = false;
              this.errorProvider1.SetError(control, Resources.RequiredFieldPopup);
          }
       }
       if (!isValid) return;
      }
