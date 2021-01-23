    void CanSave(....)
    {
       bool canSave = GetValueBlahBlah();
       if (tb.IsVisible != canSave)
           tb.Visibility = canSave ? Visibility.Visible : Visibility.Collapsed;
    }
