    using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
    {
    	using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
    	{
    		foreach (var session in sessionEnumerator)
    		{
    			//one of the sessions is might be google chrome
    			//implement your logic to select the correct session
    
    			using (var meterInformation = session.QueryInterface<AudioMeterInformation>())
    			{
    				var peak = meterInformation.PeakValue;
    				//implement your logic
    			}
    		}
    	}
    }
    
    ... 
    
    private AudioSessionManager2 GetDefaultAudioSessionManager2(DataFlow dataFlow)
    {
    	using (var enumerator = new MMDeviceEnumerator())
    	{
    		using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
    		{
    			Debug.WriteLine("DefaultDevice: " + device.FriendlyName);
    			var sessionManager = AudioSessionManager2.FromMMDevice(device);
    			return sessionManager;
    		}
    	}
    }
