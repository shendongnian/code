    {
        // dialog
        {
            if (onValidate()) {
                DialogResult = DialogResult.OK;
            }
        }
        private bool onValidate() {
           CancelEventHandler handler = Validate;
           if (handler == null) {
               return true;
           }
           CancelEventArgs args = new CancelEventArgs();
           handler(this, args);
           return args.Cancel;
        }
    }
    {
        // form
        {
            dlgUserDetail.Validate += valid;
            if(dlgUserDetail.ShowDialog() == DialogResult.OK) { }
        }
        private void valid(object sender, CancelEventArgs e) {
            // check input and set
            e.Cancel = true;
            // if not valid
        }
    }
