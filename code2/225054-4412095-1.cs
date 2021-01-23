    using System;
    using WMPLib;
    
    namespace MediaPlayer
    {
        class Program
        {
            static WindowsMediaPlayer wmp = new WindowsMediaPlayer();
    
            static void Main(string[] args)
            {
                wmp.URL = @"c:\Wildlife.wmv";
                wmp.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(wmp_PlayStateChange);
                Console.ReadKey();
            }
    
            static void wmp_PlayStateChange(int NewState)
            {
                if (NewState == 3)
                {
                    Console.WriteLine("Duration = " + wmp.currentMedia.durationString);
                }
            }
        }
    }
