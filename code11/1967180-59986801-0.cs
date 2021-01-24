if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
{
    var usernameField = new UITextField
    {
        usernameField.TextContentType = UITextContentType.Username;
    };
    var passwordField = new UITextField
    {
        passwordField.TextContentType = UITextContentType.Password;
    };
}
OS will detect such fields and add AutoFill option
