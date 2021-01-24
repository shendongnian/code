    TextViewDelegate textViewDelegate;
    
    public override void ViewDidLoad ()
    {
         base.ViewDidLoad ();
         
         textViewDelegate = new TextViewDelegate(MyTextView);
         MyTextView.Delegate = textViewDelegate; //MyTextView from StoryBoard
    
    }
    
    partial void SetTrueButton_TouchUpInside(UIButton sender)
    {
        textViewDelegate.setSecureTextViewEntry(true);
    }
    
    partial void SetFalseButton_TouchUpInside(UIButton sender)
    {
        textViewDelegate.setSecureTextViewEntry(false);
    }
