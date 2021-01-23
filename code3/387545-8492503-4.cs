     public void Main() {
       // ...
       var loginData = new LoginData { UserName = "test" };
       LoginForm.Execute(loginData);
       if (loginData.Result == DialogResult.OK) {
          // ....
       }
  
       // ...
     }
