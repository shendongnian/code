    class Consumer
    {
        //...
    
        public void Consume()
        {
            int value = 0;
            for (int i = 1; i <= 4; i++)
            {
                if( blockingIntQueue.TryDequeue(out value) )
                {
                    sum += value;
                }
            }
        }
    }
