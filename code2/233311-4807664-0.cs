    int WaitForClick ()
    {
        int clicked = -1;
        var x = new UIAlertView ("Title", "Message",  null, "Cancel", "OK", "Perhaps");
        x.Show ();
        bool done = false;
        x.Clicked += (sender, buttonArgs) => {
            Console.WriteLine ("User clicked on {0}", buttonArgs.ButtonIndex);
    	clicked = buttonArgs.ButtonIndex;
        };    
        while (clicked == -1){
            NSRunLoop.Current.RunUntil (NSDate.FromTimeIntervalSinceNow (0.5));
            Console.WriteLine ("Waiting for another 0.5 seconds");
        }
        
        Console.WriteLine ("The user clicked {0}", clicked);
        return clicked;
    }
