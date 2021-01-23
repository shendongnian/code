    internal void ProcessEvents()
    {
        while (true)
        {
            try
            {
                var myEvent = _blockingCollection.Take();
                Console.WriteLine("Received event");
            }
            catch(ThreadInterruptedException)
            {
                Console.WriteLine("Thread interrupted!");
                break;// break out of the loop!
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Do you REALLY want to keep going if there is an unexpected exception?
                // Consider breaking out of the loop...
            } 
        } 
    } 
