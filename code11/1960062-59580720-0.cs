    public override void LayoutSubviews()
    {
    
       base.LayoutSubviews();
    
                CGRect frame = this.top.Frame; // save frame
                frame.Height = this.Bounds.Size.Height + 20f; //modify frame
                //Frame.Offset(0, 20); dunno can play with this too
                this.Frame = frame; // set modifyed
    }
