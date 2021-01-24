    using (WebClient cln = new WebClient())
    {
    	try
    	{
    		FileSavePicker picker = new FileSavePicker();
    		picker.FileTypeChoices.Add("PNG File", new List<string>() { ".png" });
    		picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
    
    		var file = await picker.PickSaveFileAsync();
    		  // Prevent updates to the remote version of the file until we finish making changes and call CompleteUpdatesAsync.
            CachedFileManager.DeferUpdates(file);
            // write to file
            await FileIO.WriteTextAsync(file, file.Name);
            // Let Windows know that we're finished changing the file so the other app can update the remote version of the file.
            // Completing updates may require Windows to ask for user input.
            FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
            if (status == FileUpdateStatus.Complete)
            {
    			cln.DownloadFile("https://i.redd.it/o8rz4s0lxp021.png", file.Path);
    		}
    	}
    	catch (Exception e)
    	{
    		Debug.WriteLine(e);
    	}
    }
