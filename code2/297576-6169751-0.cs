    private void LayoutRoot_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
    {
        startY = e.ManipulationOrigin.Y;
    }
    
    private void LayoutRoot_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
    {
         endY = e.ManipulationOrigin.Y;
    	       
         if(endY - startY > 0)
            MessageBox.Text("Down")
         else 
            MessageBox.Text("Up"); 
            //add check to see if it equals zero in which case the user didn't swipe
    }
