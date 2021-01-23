     public static LoginFormResult Execute() {
         using (var f = new LoginForm()) {
             var result = new LoginFormResult();
             result.Result = f.ShowDialog();
             result.UserName = f.txtUserName.Text;
             // ....
             return result;
         }
     }
