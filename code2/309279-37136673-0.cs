    public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    // Brief:   Handle data received event
    {
      // Read the data
      // ~~~~~~~~~~~~~
      // Check for unsubscribe
      // ~~~~~~~~~~~~~~~~~~~~~
      if (bStopDataRequested)
      {
        serialPort1.DataReceived -= DataReceivedHandler;  // Unsubscribe to DataReceived event
        // Only then close the port
      }
    }
