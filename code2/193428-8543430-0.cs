    using System;
    using System.Collections.Generic; 
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.IO;
    //using System.Timers;
    
    namespace Screen
    {
        public partial class Form1 : Form
       {
            public Form1()
            {
                InitializeComponent();
            }
            [DllImport("user32.dll")]
            public static extern bool SystemParametersInfo(UInt32 uiAction, UInt32 uiParam,     string pvParam, UInt32 fWinIni);
            static FileInfo[] images;
            static int currentImage;
            
            private void timer1_Tick(object sender, EventArgs e)
            {            
                const uint SPI_SETDESKWALLPAPER = 20;
                const int SPIF_UPDATEINIFILE = 0x01;
                const int SPIF_SENDWININICHANGE = 0x02;
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0,     images[currentImage++].FullName, SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE);
                currentImage = (currentImage >= images.Length) ? 0 : currentImage;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\TEMP");
                images = dirInfo.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);
                currentImage = 0;
            }
        }
    }
