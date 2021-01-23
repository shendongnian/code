     DateTime start = new DateTime(2010, 12, 31, 12, 0, 0);
     TimeSpan frameLength = new TimeSpan(0, 0, 3);
     DateTime testTime = new DateTime(2010, 12, 31, 12, 0, 4);
     
     int frameIndex = 0;
     while (testTime >= start)
     {
         frameIndex++;
         start = start.Add(frameLength);
     }
    
     Console.WriteLine(frameIndex);
