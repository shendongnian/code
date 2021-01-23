           protected override void OnLoad(EventArgs args)
            {
                Application.Idle += new EventHandler(OnLoaded);
            }
    
            public void OnLoaded(object sender, EventArgs args)
            {
                Application.Idle -= new EventHandler(OnLoaded);
               // rest of your code 
            }
