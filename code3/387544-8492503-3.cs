     public static void Execute(LoginFormData data) {
         using (var f = new LoginForm()) {
             f.txtUserName.Text = data.UserName ?? "";
             // ...
             data.Result = f.ShowDialog();
             if (data.Result == DialogResult.OK) {
               data.UserName = f.txtUserName.Text;
               // ....
             }
         }
     }
