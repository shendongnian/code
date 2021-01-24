    private static void SetElemento(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ElementoControl elementoControl = new ElementoControl();
        //  Why are you checking to see if this is null? You just created it. 
        if (elementoControl != null)
        {
