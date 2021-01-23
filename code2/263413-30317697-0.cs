    private void ActivateScanner(DeviceInfo selectedScanner)
    {
        //Verify that the selectedScanner is not null
        // and that it is not the same scanner already selected
        if (selectedScanner != null && !selectedScanner.IsDeviceInfoOf(activeScanner))
        { 
            // Configure the new scanner
            DeactivateScanner();
    
            // Activate the new scanner
            UpdateEventHistory(string.Format(Activate Scanner: {0}",
                selectedScanner.ServiceObjectName));
            try
            {
                activeScanner = (Scanner)explorer.CreateInstance(selectedScanner);
                activeScanner.Open();
                activeScanner.Claim(1000);
                activeScanner.DeviceEnabled = true;
                activeScanner.DataEvent += newDataEventHandler(activeScanner_DataEvent);
                activeScanner.ErrorEvent += new DeviceErrorEventHandler(
                    activeScanner_ErrorEvent);
                activeScanner.DecodeData = true;
                activeScanner.DataEventEnabled = true;
            }
            catch (PosControlException)
            {
                // Log error and set the active scanner to none
                UpdateEventHistory(string.Format(Activation Failed: {0}",
                    selectedScanner.ServiceObjectName));
                activeScanner = null;
            }
        }
