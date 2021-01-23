    private static void ChangeMyControlTextFromCache(string controlName, string newText, Panel containingPanel)
    {
        MyControl original = ViewState[controlName] as MyControl;
        if (original == null)
        {
            original = new MyControl();
            ViewState[controlName] = original;
        }    
        MyControl clone = CloneMyControl(original);
        clone.Text = newText;
        if (containingPanel.Children.Contains(original))
            containingPanel.Children.Remove(original);
        containingPanel.Children.Add(clone);
    }
    
    private static MyControl CloneMyControl(MyControl original)
    {
        MyControl clone = new MyControl();
        clone.Text = original.Text;
        clone.SomeOtherProperty = original.SomeOtherProperty;
        return clone;
    }
