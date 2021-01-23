    public static readonly DependencyProperty ProtectionProperty =
        DependencyProperty.Register("Protection",
            typeof(Field3270Attributes.Protection),
            typeof(Textfield3270),
            new FrameworkPropertyMetadata(Field3270Attributes.Protection.AUTOSKIP, setProtection));
