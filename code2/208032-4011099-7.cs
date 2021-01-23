    public class MyImage
    {
        public MyImage(string sourcePath)
        {
            this.SourcePath = sourcePath;
            //This is where you could possibly do the tests. some examples of how you would do them are given below
            //You could move these validations into the SourcePath property, it all depends on the usage of the class
            if(this.height != 32)
                throw new InvalidImageException("Height is not valid", this);
            if(this.Width != 32)
                throw new InvalidImageException("Width is not valid",this);
            //etc etc
        }
        public string SourcePath { get; private set; }
    }
