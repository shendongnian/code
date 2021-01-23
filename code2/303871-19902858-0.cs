    public void buttonCase(object sender, RoutedEventArgs e)
    {
        if (((App)App.Current).appControler.m_Mode == Controller.textMode.Letters)
        {
            ((App)App.Current).appControler.buttonCase(sender, e);
            switch (((App)App.Current).appControler.m_case)
            {
            case Controller.caseMode.Upper:
                VisualStateManager.GoToState( this, "UpperCase", true );
                break;
            case Controller.caseMode.Lower:
                VisualStateManager.GoToState( this, "LowerCase", true );
                break;
            }
        }
    }  
