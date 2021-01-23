        [System.Drawing.ToolboxBitmap(typeof(WebCamCapture), "CAMERA.ICO")] // toolbox bitmap
    [Designer("Sytem.Windows.Forms.Design.ParentControlDesigner,System.Design", typeof(System.ComponentModel.Design.IDesigner))] // make composite
    public class WebCamCapture : System.Windows.Forms.UserControl
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer timer1;
        // property variables
        private int m_TimeToCapture_milliseconds = 100;
        private int m_Width = 320;
        private int m_Height = 240;
        private int mCapHwnd;
        private ulong m_FrameNumber = 0;
       //-->made private to public, now it is working fine
        public class WebcamEventArgs
        {
            public Image WebCamImage;
        }
        // global variables to make the video capture go faster
        private WebCamCapture.WebcamEventArgs x = new WebCamCapture.WebcamEventArgs();
        private IDataObject tempObj;
        private System.Drawing.Image tempImg;
        private bool bStopped = true;
        // event delegate
      -->Error in the below line
     public delegate void WebCamEventHandler(object source, WebCamCapture.WebcamEventArgs e);
     <--
        // fired when a new image is captured
        public event WebCamEventHandler ImageCaptured;
        #region API Declarations
        #region Camera API Constants
