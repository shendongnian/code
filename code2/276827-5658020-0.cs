		private delegate void UpdateProgessCallback(Int64 BytesRead, Int64 TotalBytes);
		private void Download(string url, string localPath)
		{
			using (WebClient wcDownload = new WebClient())
			{
				try
				{
					// Create a request to the file we are downloading
					webRequest = (HttpWebRequest)WebRequest.Create(url);
					// Set default authentication for retrieving the file
					webRequest.Credentials = CredentialCache.DefaultCredentials;
					// Retrieve the response from the server
					webResponse = (HttpWebResponse)webRequest.GetResponse();
					// Ask the server for the file size and store it
					Int64 fileSize = webResponse.ContentLength;
					// Open the URL for download 
					strResponse = wcDownload.OpenRead(txtUrl.Text);
					// Create a new file stream where we will be saving the data (local drive)
					strLocal = new FileStream(string localPath, FileMode.Create, FileAccess.Write, FileShare.None);
					// It will store the current number of bytes we retrieved from the server
					int bytesSize = 0;
					// A buffer for storing and writing the data retrieved from the server
					byte[] downBuffer = new byte[2048];
					// Loop through the buffer until the buffer is empty
					while ((bytesSize = strResponse.Read(downBuffer, 0, downBuffer.Length)) > 0)
					{
						// Write the data from the buffer to the local hard drive
						strLocal.Write(downBuffer, 0, bytesSize);
						// Invoke the method that updates the form's label and progress bar
						this.Invoke(new UpdateProgessCallback(this.UpdateProgress), new object[] { strLocal.Length, fileSize });
					}
				}
				finally
				{
					// When the above code has ended, close the streams
					strResponse.Close();
					strLocal.Close();
				}
			}
		private void UpdateProgress(Int64 BytesRead, Int64 TotalBytes)
		{
			// Calculate the download progress in percentages
			PercentProgress = Convert.ToInt32((BytesRead * 100) / TotalBytes);
			// Make progress on the progress bar
			prgDownload.Value = PercentProgress;
			// Display the current progress on the form
			lblProgress.Text = "Downloaded " + BytesRead + " out of " + TotalBytes + " (" + PercentProgress + "%)";
			if (BytesRead == TotalBytes)
			{
			//done
			}
		}
