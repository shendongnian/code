    using Captura;
    using System;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Using MotionJpeg as Avi encoder,
                // output to 'out.avi' at 10 Frames per second, 70% quality
                var rec = new Recorder(new RecorderParams("out.avi", 10, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 70));
    
                Console.WriteLine("Press any key to Stop...");
                Console.ReadKey();
    
                // Finish Writing
                rec.Dispose();
            }
        }
    }
