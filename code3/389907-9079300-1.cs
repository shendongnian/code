    protected void OnMediaFailed(object sender, CustomEventArgs<Exception> e)
    {
        if (e.Value.Message.StartsWith("6028"))
        {
            //Get Manifest Info Somehow
             ........
            //our custom acquirer initialization
            var acquirer = new ManualLicenseAcquirer(); 
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
