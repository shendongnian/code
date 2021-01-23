 		//Create varriables
		string ffMPEG = System.IO.Path.Combine(Application.StartupPath, "ffMPEG.exe");
		system.Diagnostics.Process mProcess = null;
		System.IO.StreamReader SROutput = null;
		string outPut = "";
		string filepath = "D:\\source.mp4";
		string param = string.Format("-i \"{0}\"", filepath);
		System.Diagnostics.ProcessStartInfo oInfo = null;
		System.Text.RegularExpressions.Regex re = null;
		System.Text.RegularExpressions.Match m = null;
		TimeSpan Duration =  null;
		//Get ready with ProcessStartInfo
		oInfo = new System.Diagnostics.ProcessStartInfo(ffMPEG, param);
		oInfo.CreateNoWindow = true;
		//ffMPEG uses StandardError for its output.
		oInfo.RedirectStandardError = true;
		oInfo.WindowStyle = ProcessWindowStyle.Hidden;
		oInfo.UseShellExecute = false;
		// Lets start the process
		mProcess = System.Diagnostics.Process.Start(oInfo);
		// Divert output
		SROutput = mProcess.StandardError;
		// Read all
		outPut = SROutput.ReadToEnd();
		// Please donot forget to call WaitForExit() after calling SROutput.ReadToEnd
		mProcess.WaitForExit();
		mProcess.Close();
		mProcess.Dispose();
		SROutput.Close();
		SROutput.Dispose();
		//get duration
		re = new System.Text.RegularExpressions.Regex("[D|d]uration:.((\\d|:|\\.)*)");
		m = re.Match(outPut);
		if (m.Success) {
			//Means the output has cantained the string "Duration"
			string temp = m.Groups(1).Value;
			string[] timepieces = temp.Split(new char[] {':', '.'});
			if (timepieces.Length == 4) {
				// Store duration
				Duration = new TimeSpan(0, Convert.ToInt16(timepieces[0]), Convert.ToInt16(timepieces[1]), Convert.ToInt16(timepieces[2]), Convert.ToInt16(timepieces[3]));
			}
		}
