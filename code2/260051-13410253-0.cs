    public static ResultFromFrmMain Execute() {
         using (var f = new frmMain()) {
              f.buttonOK.DialogResult = DialogResult.OK;
              f.buttonCancel.DialogResult = DialogResult.Cancel;
              var result = new ResultFromFrmMain();
              result.Result = f.ShowDialog();
              if (result.Result == DialogResult.OK) {
                 // fill other values
              }
              return result;
         }
    }
