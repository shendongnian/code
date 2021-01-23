    abstract class AudioFile
    {
        public virtual string Title { get; set; } 
    }
    
    class MpegFile : AudioFile
    {
        public override string Title { /* your custom getter and setter */ }
    }
    
    AudioFile file = new MpegFile();
    string title = file.Title; // will use override
