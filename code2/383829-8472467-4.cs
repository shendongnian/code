    public sealed class Screensaver
    {
        Screensaver() { }
        const int SPI_SETSCREENSAVEACTIVE = 0x0011;
        [DllImport("user32", CharSet=CharSet.Auto)]
        unsafe public static extern short SystemParametersInfo (int uiAction, int uiParam, int* pvParam, int fWinIni);
        public static void Set(string path)
        {
            try
            {
                RegistryKey oKey = Registry.CurrentUser.OpenSubKey("Control Panel",
                true);
                oKey = oKey.OpenSubKey("desktop", true);
                oKey.SetValue("SCRNSAVE.EXE", path);
                oKey.SetValue("ScreenSaveActive", "1");
                unsafe
                {
                    int nX = 1;
                    SystemParametersInfo(
                    SPI_SETSCREENSAVEACTIVE,
                    0,
                    &nX,
                    0
                    );
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.ToString());
            }
        }
    }
