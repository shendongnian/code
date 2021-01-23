     static Dictionary<string, VideoProcessor> processors = 
             new Dictionary<string, VideoProcessor();
     static void HandleVideoConnectionEvent(int port, string deviceId)
     {
        processors.Add(deviceId, new VideoProcessor(port, deviceId));
     }
