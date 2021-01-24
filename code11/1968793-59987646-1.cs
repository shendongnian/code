    class QueueModel
    {
        private readonly Queue<bool> status;
        public QueueModel(int lightCount)
        {
            // here queue is empty, the parameter is for the capacity
            status = new Queue<bool>(lightCount);
            // Set all light to off
            for (var i = 0; i < lightCount; i++)
                status.Enqueue(false);
        }
        public void Update(bool headLightStatus)
        {
            status.Dequeue(); // forget about the last status
            status.Enqueue(headLightStatus);
        }
    }
