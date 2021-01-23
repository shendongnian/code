    public static DependencyProperty IconTypeProperty = DependencyProperty.Register("IconType", typeof(DialogIconType), typeof(DialogContext));
    public DialogIconType IconType
    {
    	get { return (DialogIconType)(GetValue(IconTypeProperty)); }
    	set { SetValue(IconTypeProperty , value); }
    }
