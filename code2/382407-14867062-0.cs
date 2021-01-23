    private UIAlertView _loginScreen; // Declare reference.
    private UITextField _usernameField; // Declare reference.
    private UITextField _passwordField; // Declare reference.
    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();            
        _loginScreen = new UIAlertView(); // Set reference.
        _loginScreen.Title = "Login";            
        _loginScreen.AlertViewStyle = UIAlertViewStyle.LoginAndPasswordInput;
        _loginScreen.AddButton ("Cancel");
        //username
        _usernameField = _loginScreen.GetTextField(0); // Set reference.
        _usernameField.KeyboardType = UIKeyboardType.Default;
        _usernameField.ReturnKeyType = UIReturnKeyType.Next;
        _usernameField.ClearButtonMode = UITextFieldViewMode.WhileEditing;
        //password
        _passwordField = _loginScreen.GetTextField(1); // Set reference.
        _passwordField.KeyboardType = UIKeyboardType.Default;
        _passwordField.ReturnKeyType = UIReturnKeyType.Next;
        _passwordField.ClearButtonMode = UITextFieldViewMode.WhileEditing;
    
        //(Error SIGSEV happens here!!! and the resignfirstresponder doesn't work)
        _passwordField.ShouldReturn = (tf) => // Use reference.
        {
            // This delegate will be executed at a later time, ensure its owner
            // object is rooted with a reference.
            tf.ResignFirstResponder();
            return true;
        } ;
        _loginScreen.Show();
    }
