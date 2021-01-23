    public static frmMainResult Execute() {
         using (var f = new frmMain()) {
              var result = new frmMainResult;
              result.Result = f.ShowDialog();
              if (result.Result == DialogResult.OK) {
                 // fill other values
              }
              return result;
         }
    }
