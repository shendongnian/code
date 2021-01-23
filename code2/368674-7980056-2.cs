    private void test()
        {
            lock(this)
            {
                Monitor.Wait(this); //Will stop the thread until a pulse has been recieved.
                Invoke(new setLabelMethod(setLabelValue), "yeah");
            }
        }
