    using System.Drawing;
    
    namespace WindowsService1
    {
        public partial class Service1 : ServiceBase
        {
            public Service1()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                Bitmap myBitmap = new Bitmap(100,100);
                Graphics g = Graphics.FromImage(myBitmap);
    
    
            }
    
            protected override void OnStop()
            {
            }
        }
    }
