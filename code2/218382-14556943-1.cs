    public void ReadData()
    {
        int counter = 0;
        while (SerialData.IsOpen)
        {
            if (counter == 0)
            {
                //try
                //{
                    InputSpeed = Convert.ToInt16(SerialData.ReadChar());
                    CurrentSpeed = InputSpeed;
                    if (CurrentSpeed > MaximumSpeed)
                    {
                        MaximumSpeed = CurrentSpeed;
                    }
	    SpeedTextBox.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
		    new Action(delegate() { SpeedTextBox.Text = "Current Wheel Speed = " + Convert.ToString(CurrentSpeed) + "Km/h"; });//update GUI from this thread
                    
                    DistanceTravelled = DistanceTravelled + (Convert.ToInt16(CurrentSpeed) * Time);
	    DistanceTravelledTextBox.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
		    new Action(delegate() {DistanceTravelledTextBox.Text = "Total Distance Travelled = " + Convert.ToString(DistanceTravelled) + "Km"; });//update GUI from this thread
                    
                //}
                //catch (Exception) { }
            }
            if (counter == 1)
            {
                try
                {
                    RiderInput = Convert.ToInt16(SerialData.ReadLine());
                    if (RiderInput > maximumRiderInput)
                    {
                        maximumRiderInput = RiderInput;
                    }                       
	    RiderInputTextBox.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, 
		    new Action(delegate() { RiderInputTextBox.Text = "Current Rider Input Power =" + Convert.ToString(RiderInput) + "Watts"; });//update GUI from this thread
                }
                catch (Exception) { }
            }
            if (counter == 2)
            {
                try
                {
                    MotorOutput = Convert.ToInt16(SerialData.ReadLine());
                    if (MotorOutput > MaximumMotorOutput)
                    {
                        MaximumMotorOutput = MotorOutput;
                    }
	    MotorOutputTextBox.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, 
		    new Action(delegate() { MotorOutputTextBox.Text = "Current Motor Output = " + Convert.ToString(MotorOutput) + "Watts"; });//update GUI from this thread                        
                }
                catch (Exception) { }
            }
            counter++;
            if (counter == 3)
            {
                counter = 0;
            }
        }
    }
