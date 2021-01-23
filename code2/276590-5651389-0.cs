         // Set up the delays for the ToolTip.
         toolTip1.AutoPopDelay = 5000;
         toolTip1.InitialDelay = 1000;
         toolTip1.ReshowDelay = 500;
         // Force the ToolTip text to be displayed whether or not the form is active.
         toolTip1.ShowAlways = true;
			
         // Set up the ToolTip text for the Button .
         toolTip1.SetToolTip(this.button1, "My button1");
