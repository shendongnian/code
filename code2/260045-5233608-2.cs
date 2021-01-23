    public static ResultFromFrmMain Execute() {
         using (var f = new frmMain()) {
              var result = new ResultFromFrmMain();
              result.Result = f.ShowDialog();
              if (result.Result == DialogResult.OK) {
                 // fill other values
              }
              return result;
         }
    }
