    using WMPLib;
    class Program
    {
        static void Main(string[] args)
        {
            // this file is called Interop.WMPLib.dll
            WindowsMediaPlayer wmp = new WindowsMediaPlayer();
            wmp.URL = @"c:\TORRENT.KG\Assault.girls.2009.DVDRip.Rus.Eng.avi";
            wmp.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(wmp_PlayStateChange);
            Console.ReadKey();
        }
    
        void wmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 3)
            {
                Console.WriteLine("Duration = " + wmp.currentMedia.durationString);
            }
        }
    }
