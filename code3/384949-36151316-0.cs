    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace WallpaperWhizz
    {
        public sealed class Wallpaper
        {
            [DllImport("user32.dll")]
            public static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);
    
            public static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
            public static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
            public static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;
            
            public enum Style : int
            {
                Tiled,
                Centered,
                Stretched
            }
            
            public static bool Set(string filePath, Style style)
            {
                bool Success = false;
                try
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(Path.GetFullPath(filePath));
    
                    string TempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
    
                    i.Save(TempPath, System.Drawing.Imaging.ImageFormat.Bmp);
    
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
    
                    switch (style)
                    {
                        case Style.Stretched:
                            key.SetValue(@"WallpaperStyle", 2.ToString());
    
                            key.SetValue(@"TileWallpaper", 0.ToString());
    
                            break;
    
                        case Style.Centered:
                            key.SetValue(@"WallpaperStyle", 1.ToString());
    
                            key.SetValue(@"TileWallpaper", 0.ToString());
    
                            break;
    
                        default:
                        case Style.Tiled:
                            key.SetValue(@"WallpaperStyle", 1.ToString());
    
                            key.SetValue(@"TileWallpaper", 1.ToString());
    
                            break;
    
                    }
    
                    SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, TempPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    
                    Success = true;
    
                }
                catch //(Exception ex)
                {
                    //ex.HandleException();
                }
                return Success;
            }
    
        }
    
    }
