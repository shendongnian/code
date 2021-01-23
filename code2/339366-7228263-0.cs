    byte[] byteBLOBData = (byte[])ds.Tables["magazine_images"].Rows[c - 1]["image"];
    string tempImageFileName = Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".jpg");
    using( FileStream fileStream = new FileStream(tempImageFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite) ) {
    	using( BinaryWriter writer = new BinaryWriter(fileStream) ) {
    		writer.Write(byteBLOBData);
    	}
    }
    
    pictureBox1.LoadCompleted += LoadCompleted;
    pictureBox1.WaitOnLoad = false;
    pictureBox1.LoadAsync(tempImageFileName);
...
    private static void LoadCompleted( object sender, AsyncCompletedEventArgs e ) {
    	if( e.Error != null ) {
    		// will get this if there's an error loading the file
    	} if( e.Cancelled ) {
    		// would get this if you have code that calls pictureBox1.CancelAsync()
    	} else {
    		// picture was loaded successfully
    	}
    }
