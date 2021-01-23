    INameScope scope = NameScope.GetNameScope(this);
    scope.UnregisterName("btn");
    btn = new System.Windows.Controls.Button();
    Content = btn;
    scope.RegisterName("btn", btn);
