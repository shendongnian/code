        /// <summary>
		/// Prepares the upload.
		/// </summary>
		/// <returns>The upload.</returns>
		public async Task PrepareUpload()
		{
			try {
				Console.WriteLine("PrepareUpload called...");
				if (session == null)
					session = InitBackgroundSession();
				// Check if task already exits
				var tsk = await GetPendingTask();
				if (tsk != null) {
					Console.WriteLine ("TaskId {0} found, state: {1}", tsk.TaskIdentifier, tsk.State);
					// If our task is suspended, resume it.
					if (tsk.State == NSUrlSessionTaskState.Suspended) {
						Console.WriteLine ("Resuming taskId {0}...", tsk.TaskIdentifier);
						tsk.Resume();
					}
					return; // exit, we already have a task
				}
				// For demo purposes file is attached to project as "Content" and PDF is 8.1MB.
				var fileToUpload = "UIKitUICatalog.pdf";
				if(File.Exists(fileToUpload)) {
					var boundary = "FileBoundary";
					var bodyPath = Path.Combine (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BodyData.tmp");
					// Create request
					NSUrl uploadHandleUrl = NSUrl.FromString (webApiAddress);
					NSMutableUrlRequest request = new NSMutableUrlRequest (uploadHandleUrl);
					request.HttpMethod = "POST";
					request ["Content-Type"] = "multipart/form-data; boundary=" + boundary;
					request ["FileName"] = Path.GetFileName(fileToUpload);
					// Construct the body
					System.Text.StringBuilder sb = new System.Text.StringBuilder("");
					sb.AppendFormat("--{0}\r\n", boundary);
					sb.AppendFormat("Content-Disposition: form-data; name=\"file\"; filename=\"{0}\"\r\n", Path.GetFileName(fileToUpload));
					sb.Append("Content-Type: application/octet-stream\r\n\r\n");
					// Delete any previous body data file
					if (File.Exists(bodyPath))
						File.Delete(bodyPath);
					// Write file to BodyPart
					var fileBytes = File.ReadAllBytes (fileToUpload);
					using (var writeStream = new FileStream (bodyPath, FileMode.Create, FileAccess.Write, FileShare.Read)) {
						writeStream.Write (Encoding.Default.GetBytes (sb.ToString ()), 0, sb.Length);
						writeStream.Write (fileBytes, 0, fileBytes.Length);
						sb.Clear ();
						sb.AppendFormat ("\r\n--{0}--\r\n", boundary);
						writeStream.Write (Encoding.Default.GetBytes (sb.ToString ()), 0, sb.Length);
					}
					sb = null;
					fileBytes = null;
					// Creating upload task
					var uploadTask = session.CreateUploadTask(request, NSUrl.FromFilename(bodyPath));
					Console.WriteLine ("New TaskID: {0}", uploadTask.TaskIdentifier);
					// Start task
					uploadTask.Resume (); 
				}
				else
				{
					Console.WriteLine ("Upload file doesn't exist. File: {0}", fileToUpload);
				}	
			} catch (Exception ex) {
				Console.WriteLine ("PrepareUpload Ex: {0}", ex.Message);
			}
		}
