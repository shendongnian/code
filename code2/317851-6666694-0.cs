    using System;
    using System.Diagnostics;
    
    namespace csharp_station.howto
    {
        /// <summary>
        /// Demonstrates how to start another program from C#
        /// </summary>
        class ProcessStart
        {
            static void Main(string[] args)
            {
                Process java = new Process();
    
                java.StartInfo.FileName   = "java";
                java.StartInfo.Arguments = "-Xms1024M -Xmx1024M -jar craftbukkit-0.0.1-SNAPSHOT.jar nogui";
    
                java.Start();
            }
        }
}
