    public event BeforeDelegate OnBefore();
    public event AfterDelegate OnAfter();
    private EnumType enumValue;
    public EnumType EnumValue
    {
        get {
            return enumValue;
        }
        set{
            this.enumValue = value;
            if(enumValue == DoStuff.Before)
                if(OnBefore!=null)
                    OnBefore();
            if(enumValue == DoStuff.After)
                if(OnAfter!=null)
                    OnAfter();
        }
    }
}
