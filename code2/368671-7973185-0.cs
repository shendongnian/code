    private void test()
        {
            do
            {
                if (done)
                {
                    Invoke(new setLabelMethod(setLabelValue), "yeah");
                    done = false;
                    running = false;
                }
                Thread.Sleep(500); 
            } while (running);
        }
