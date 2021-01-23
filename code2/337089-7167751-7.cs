    class Producer
    {
        //...
    
        public void Produce()
        {
            for (int i = 1; i <= 4; i++)
            {
                Thread.Sleep(randomSleepTime.Next(1, 3000));
                blockingIntQueue.Enqueue(i);
            }
        }
    }
