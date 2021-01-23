    internal bool StartStream()
    {
    	Busy = true;
    	// Instantiates a new job for encoding
    	//  
    	
    	//***************************************Live Stream Archive******************************
    	if (blnRecordFromFile)
    	{
    		
    		// Sets up publishing format for file archival type
    		FileArchivePublishFormat fileOut = new FileArchivePublishFormat();
    		
    		
    		
    		//  job.ApplyPreset(LivePresets.VC1512kDSL16x9);
    		
    		// Gets timestamp and edits it for filename
    		string timeStamp = DateTime.Now.ToString();
    		timeStamp = timeStamp.Replace("/", "-");
    		timeStamp = timeStamp.Replace(":", ".");
    		
    		// Sets file path and name
    		string path = "C:\\output\\";
    		string filename = "Capture" + timeStamp + ".ismv";
    		if (!Directory.Exists(path))
    			Directory.CreateDirectory(path);
    		
    		fileOut.OutputFileName = Path.Combine(path, filename);
    		
    		// Adds the format to the job. You can add additional formats as well such as
    		// Publishing streams or broadcasting from a port
    		job.PublishFormats.Add(fileOut);
    		
    	}
    	//******************************END OF Stream PORTION****************************************
    	
    	////////////////////////////////////////////////////////////////////////////////////////////////////
    	//*************************************** Process Files or Live Stream******************************
    	if (blnRecordFromFile)
    	{
    		job.ApplyPreset(LivePresets.VC1IISSmoothStreaming720pWidescreen);
    		
    		job = new LiveJob();
    		// Verifies all information is entered
    		if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destinationPath))
    			return false;
    		
    		job.Status += new EventHandler<EncodeStatusEventArgs>(StreamStatus);
    		
    		LiveFileSource fileSource;
    		try
    		{
    			// Sets file to active source and checks if it is valid
    			fileSource = job.AddFileSource(sourcePath);
    		}
    		catch (InvalidMediaFileException)
    		{
    			return false;
    		}
    		
    		// Sets to loop media for streaming
    		//   fileSource.PlaybackMode = FileSourcePlaybackMode.Loop;
    		
    		// Makes this file the active source. Multiple files can be added 
    		// and cued to move to each other at their ends
    		job.ActivateSource(fileSource);
    	}
    	//******************************END OF FILE PORTION****************************************
    	
    	
    	// Sets up variable for fomat data
    	switch (publishType)
    	{
    		case Output.Archive:
    			// Verifies destination path exists and if not creates it
    			try
    		{
    			if (!Directory.Exists(destinationPath))
    				Directory.CreateDirectory(destinationPath);
    		}
    			catch (IOException)
    			{
    				return false;
    			}
    			
    			FileArchivePublishFormat archiveFormat = new FileArchivePublishFormat();
    			
    			// Gets the location of the old extention and removes it
    			string filename = Path.GetFileNameWithoutExtension(sourcePath);
    			
    			// Sets the archive path and file name
    			archiveFormat.OutputFileName = Path.Combine(destinationPath, filename + ".ismv");
    			job.PublishFormats.Add(archiveFormat);
    		break;
    			
    		case Output.Publish:
    			// Setups streaming of media to publishing point 
    			job = new LiveJob();
    			
    			// Aquires audio and video devices
    			Collection<EncoderDevice> devices = EncoderDevices.FindDevices(EncoderDeviceType.Video);
    			EncoderDevice video = devices.Count > 0 ? devices[0] : null;
    			for (int i = 0; i < devices.Count; ++i)
    				//  devices[i].Dispose();
    				devices.Clear();
    			
    			devices = EncoderDevices.FindDevices(EncoderDeviceType.Audio);
    			EncoderDevice audio = devices.Count > 0 ? devices[0] : null;
    			for (int i = 1; i < devices.Count; ++i)
    				devices[i].Dispose();
    			devices.Clear();
    			
    			// Checks for a/v devices
    			if (video != null && audio != null)
    			{
    				
    				
    				//job.ApplyPreset(Preset.FromFile(@"C:\Tempura\LivePreset3.xml"));
    				job.ApplyPreset(LivePresets.H264IISSmoothStreamingLowBandwidthStandard);
    				job.OutputFormat.VideoProfile.SmoothStreaming = true;
    				deviceSource = job.AddDeviceSource(video, audio);
    				
    				// Make this source the active one
    				job.ActivateSource(deviceSource);
    			}
    			else
    			{
    				error = true;
    			}
    			
    			PushBroadcastPublishFormat publishFormat = new PushBroadcastPublishFormat();
    			try
    		{
    			// checks the path for a valid  publishing point
    			publishFormat.PublishingPoint = new Uri(destinationPath);
    			
    		}
    			catch (UriFormatException)
    			{
    				return false;
    			}
    			
    			// Adds the publishing format to the job
    			
    			try
    		{
    			
    			
    			
    			
    			// job.ApplyPreset(LivePresets.VC1IISSmoothStreaming480pWidescreen);
    			job.PublishFormats.Add(publishFormat);
    			job.PreConnectPublishingPoint();
    		}
    			catch (Exception e)
    			{
    				MessageBox.Show(e.StackTrace.ToString());
    			}
    			
    		break;
    		default:
    		return false;
    	}
    	job.StartEncoding();
    	
    	return true;
    }
