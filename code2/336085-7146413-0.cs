    public class CameraWindow : PictureBox
    {
        void Test()
        {
            this.Image; // or just Image
        }
    }
    
    public class CameraWindow : PictureBox
    {
        public override object Image
        {
            { get { return base.Image; } }// note base
        }
    }
