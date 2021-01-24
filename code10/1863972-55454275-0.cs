    public void OnSensorChanged(SensorEvent e)
    {
        // Can't tell if this is required with information available
        lock (_syncLock)
        {
            // Capture the 'new' data to a local variable
            var newValue = e.Values.Average();
            
            if (newValue != previousValue)
            {
                // Value has changed by required amount so do something here
            }
            // Update the previous so next we we use this as our reference value
            previousValue = newValue;
    }
