    string strMP3Folder = "<YOUR FOLDER PATH>";
    string strMP3SourceFilename = "<YOUR SOURCE MP3 FILENAMe>";
    string strMP3OutputFilename = "<YOUR OUTPUT MP3 FILENAME>";
    
    using (Mp3FileReader reader = new Mp3FileReader(strMP3Folder + strMP3SourceFilename))
    {
        int count = 1;
        Mp3Frame mp3Frame = reader.ReadNextFrame();
        System.IO.FileStream _fs;
        while (mp3Frame != null)
        {
            if (count > 500) //retrieve a sample of 500 frames
                return;
    
            if (count == 1)
                 _fs = new System.IO.FileStream(strMP3Folder + strMP3OutputFilename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            else
                 _fs = new System.IO.FileStream(strMP3Folder + strMP3OutputFilename, System.IO.FileMode.Append, System.IO.FileAccess.Write);
    
            _fs.Write(mp3Frame.RawData, 0, mp3Frame.RawData.Length);
            _fs.Close();
    
            count = count + 1;
    
            mp3Frame = reader.ReadNextFrame();
         }
    }
