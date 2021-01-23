    private void parseBuffer()
    {
        while (true)
        {
            waitHandle.WaitOne(); // <-- waits until there is more data to parse
            //obtain lock, parse one message from buffer
            lock (this)
            {
                if (readBuffer.IndexOf("\r") > 0)
                {
                    String t = readBuffer.Substring(0, readBuffer.IndexOf("\r") + 1);
                    readBuffer = readBuffer.Replace(t, "");
                    dataReady(this, new CustomEventArgs(t, null));
                }
            }
        }
    }
