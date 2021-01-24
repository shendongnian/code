    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace StringFormatting
    {
        public partial class WallpaperTest : Form
        {
            private const UInt32 SPI_GETDESKWALLPAPER = 0x73;
            private const int MAX_PATH = 260;
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int SystemParametersInfo(UInt32 uAction, int uParam, string lpvParam, int fuWinIni);
    
            public WallpaperTest()
            {
                InitializeComponent();
                this.BackgroundImage = GetCurrentDesktopWallpaper();
                this.BackgroundImageLayout = ImageLayout.Stretch; 
            }
    
            public Image GetCurrentDesktopWallpaper()
            {
                string currentWallpaper = new string('\0', MAX_PATH);
                SystemParametersInfo(SPI_GETDESKWALLPAPER, currentWallpaper.Length, currentWallpaper, 0);
                string imageAddress = currentWallpaper.Substring(0, currentWallpaper.IndexOf('\0'));
                return Image.FromFile(imageAddress); 
            }
      
    
        }
    }
