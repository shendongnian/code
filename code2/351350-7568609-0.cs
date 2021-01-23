    public class MyPage : WatiN.Core.Page
    {
        public TextField NameField
        {
            get { return Document.TextField(Find.ByName("txtName")); }
        }
        public TextField PasswordField
        {
            get { return Document.TextField(Find.ByName("txtPassword")); }
        }
        public TextField LoginButton
        {
            get { return Document.Button(Find.ByName("btnLogin")); }
        }
    }
