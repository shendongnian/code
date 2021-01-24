    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        // Perform any additional setup after loading the view, typically from a nib.
        NSMutableAttributedString mtText = new NSMutableAttributedString("testTextfield", new UIStringAttributes
        {
            Font = UIFont.SystemFontOfSize(10),
            KerningAdjustment = 8.0f
        });
        UITextField textField = new UITextField();
        textField.Frame = new CoreGraphics.CGRect(10,20,350,50);
        textField.AttributedText = mtText;        
        Add(textField);
    }
