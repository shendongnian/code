    EditText control;
    
    protected override void OnAttached()
    {
        control = Control as EditText;
        UpdateLineColor();
    }
    
    protected override void OnDetached()
    {
        control = null;
    }
    
    private void UpdateLineColor()
    {
        if (control != null)
        {
            control.Background.Mutate().SetColorFilter(Color.DarkMagenta.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcAtop);
        }
    }
