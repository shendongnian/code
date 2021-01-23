    using System.IO;
    using System.Net;
    using System.Diagnostics;
    
    // some code here...
    
    StopWatch stopWatch = new stopWatch();
    
    // Begining of the loop
    
    int offset = 0;
    stopWatch.Reset();
    stopWatch.Start();
    
    bytes[] buffer = new bytes[1024]; // 1 KB buffer
    int actualReadBytes = myStream.Read(buffer, offset, buffer.Length);
    
    // Now we have read 'actualReadBytes' bytes 
    // in 'stopWath.ElapsedMilliseconds' milliseconds.
    
    stopWatch.Stop();
    offset += actualReadBytes;
    int speed = (actualReadBytes * 8) / stopWatch.ElapsedMilliseconds; // kbps
    
    // End of the loop
