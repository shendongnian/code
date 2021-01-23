    private static readonly ModelViewPropagationItem<LoginModel, ILoginView, string> UsernamePI = new ModelViewPropagationItem<LoginModel, ILoginView, string>(m => m.Username.Value, (m, x) => m.Username.Value = x, v => v.Username, (v, x) => v.Username = x);
    private static readonly ModelViewPropagationItem<LoginModel, ILoginView, string> PasswordPI = new ModelViewPropagationItem<LoginModel, ILoginView, string>(m => m.Password.Value, (m, x) => m.Password.Value = x, v => v.Password, (v, x) => v.Password = x);
    private static readonly ModelViewPropagationGroup<LoginModel, ILoginView> GeneralPG = new ModelViewPropagationGroup<LoginModel, ILoginView>(UsernamePI, PasswordPI);
    
    public UserPrincipal Login_Click()
    {
        GeneralPG.SyncAllToModel(this.Model, this.View);
    
        return this.Model.DoLogin();
    }
