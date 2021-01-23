    foreach (String file in openFileDialog1.FileNames) 
    {
        // read file lines
        try
        {
    
			using (StreamReader sr = File.OpenText(file))
			{
				String input;
				while ((input = sr.ReadLine()) != null)
				{
					Console.WriteLine(input);
				}
				Console.WriteLine ("The end of the stream has been reached.");
			}
        }
        catch (SecurityException ex)
        {
            // The user lacks appropriate permissions to read files, discover paths, etc.
            Console.WriteLine ("Security error. Please contact your administrator for details.\n\n" +
                "Error message: " + ex.Message + "\n\n" +
                "Details (send to Support):\n\n" + ex.StackTrace
            );
        }
        catch (Exception ex)
        {
            // Could not load the file - probably related to Windows file system permissions.
            Console.WriteLine ("Cannot display the file: " + file.Substring(file.LastIndexOf('\\'))
                + ". You may not have permission to read the file, or " +
                "it may be corrupt.\n\nReported error: " + ex.Message);
        }
    }
