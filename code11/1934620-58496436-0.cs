    LoginViewModel viewModel = new LoginViewModel();
    BindingContext = viewModel
    Button loginButton = new Button
     {
       Text = "LOGIN",
     };
    loginButton.SetBinding(Button.CommandProperty, new Binding("LoginFormCommand"));
