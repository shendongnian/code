    protected void OnMediaFailed(object sender, CustomEventArgs<Exception> e)
    {
        if (e.Value.Message.StartsWith("6028"))
        {
            var cli = new WebClient();
            cli.DownloadStringCompleted += OnProtectedManifestDownloadCompleted;
            //we have used this.Playlist[this.PlayingIndex].MediaSource, 
            //but you can use your own way to create Manifest url
            cli.DownloadStringAsync(this.Playlist[this.PlayingIndex].MediaSource);
        }
	    //default error handling here
	}	
    private void OnProtectedManifestDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
	{
		MemoryStream ms;
        try
        {
            ms = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
        }
        catch (Exception ex)
        {
            this.ShowCustomError(string.Format("Getting manifest stream error: {0}", ex.Message), true, true);
            return;
        }
		
        ManifestInfo manifestInfo;
        try
        {
            manifestInfo = ManifestInfo.ParseManifest(ms, this.Playlist[this.PlayingIndex].MediaSource);
        }
        catch (Exception ex)
        {
            this.ShowCustomError(string.Format("Parsing ManifestInfo error: {0}", ex.Message), true, true);
            return;
        }
		
		var acquirer = new ManualLicenseAcquirer();
		acquirer.ChallengeCustomData = Configurator.Instance.Config.CustomData;
		
		if (manifestInfo != null 
			&& manifestInfo.ProtectionInfo != null
			&& manifestInfo.ProtectionInfo.ProtectionHeader != null)
		{
			acquirer.AcquireLicenseCompleted += this.OnLAcquirerCompleted;
			acquirer.AcquireLicenseAsync(manifestInfo.ProtectionInfo.ProtectionHeader.ProtectionData);
		}
		else
		{
			this.ShowCustomError("Manifest info is null or protection header is null", true, true);
		}
	}
    private void OnLAcquirerCompleted(object sender, AcquireLicenseCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            this.ShowCustomError(string.Format("Server response error: {0}", e.Error), true, true);
        }
        else if (e.Cancelled)
        {
            this.ShowCustomError(string.Format("Manual license acquier request was cancelled"), true, true, true);
        }
        else
        {
            this.Play();    
        }
    }
