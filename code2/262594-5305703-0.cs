    // I'm picking Button here, but any control could be put here, be it
    // Window or whatever: 
    Button b = new Button();
    
    // I'm putting some content to see that it actually measures it children.
    // If you'll put more text here  you'll see bigger size 
    b.Content = "Hello";
     
    // I'm manually measuring the control, passing in double.PositiveInfinity so
    // that the control would give me the size it wants, regardless of any
    //  constraints (you can put constraints here if you like) 
    b.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
     
    // After Measure is called, the Property DesiredSize become relevant,
    // and contains the size that the Control needs to show all of its
    // contents.			
    MessageBox.Show(b.DesiredSize.ToString());
