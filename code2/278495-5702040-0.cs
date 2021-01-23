        // create new control
        var control = new UIView(); // or UIButton, etc.
        
        // set control props ..
        control.Hidden = false;
        control.Frame = x // = Bounds
        // ...
        
        // add control to parent
        window.AddSubview(control);
