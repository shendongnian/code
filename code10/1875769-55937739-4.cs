    private static void SetElemento(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        //  If anybody calls this method with a reference to something other than 
        //  ElementoControl, that's a bug and an exception should be thrown. 
        if (!d is ElementoControl)
        {
            throw new ArgumentException("d must be ElementoControl");
        }
        ElementoControl elementoControl = d as ElementoControl;
        //  This should be done mostly in XAML as well, but I don't have time at the 
        //  moment. I would give ElementoControl a boolean readonly dependency property 
        //  called IsPingable. I would set that property here, and in the XAML I would 
        //  give the button a Style with a DataTrigger that set the Button's background 
        //  color according to the value of IsPingable. 
        #region IsPingable
        if (IsPingable((e.NewValue as Classes.Elementi).IndirizzoIP))
        {
            elementoControl.elementoButton.Background = new SolidColorBrush(Colors.DarkGreen);
        }
        else
        {
            elementoControl.elementoButton.Background = new SolidColorBrush(Colors.DarkRed);
        }
        #endregion
    }
