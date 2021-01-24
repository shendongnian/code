try
{
    if (!cameraOpened)
    {
        LogMessage("Opening camera stream...");
        var openTask = Task.Run(() => capture = new Capture("rtsp://admin:redacted@10.0.0.22:554"));
        if (await Task.WhenAny(openTask, Task.Delay(20000)) != openTask)
        {
            LogMessage("Unable to open camera stream");
        }
        else
        {
            LogMessage("Camera stream opened");
            cameraOpened = true;
        }
    }
    if (cameraOpened)
    {
        var captureTask = Task.Run(() => inputFrame = capture.QueryFrame());
        if (await Task.WhenAny(captureTask, Task.Delay(5000)) != captureTask)
        {
            LogMessage("Camera connection lost");
            cameraOpened = false;
        } 
        else
        {
            if (inputFrame != null && !inputFrame.IsEmpty)
            {
                frameQueue.Enqueue(inputFrame);
            }
        }
    }
} catch (Exception ex)
{
    LogMessage(ex.Message);
    Thread.Sleep(5000);
}
`frameQueue` is declared as follows and the processing occurs in a separate thread which might help things as well. I wrote the code quite a while ago, instead of the this I'd now use the `ConcurrentQueue` class.
Queue myQ = new Queue();
Queue frameQueue = Queue.Synchronized(myQ);
