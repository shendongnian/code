    public class InputHandler
    {
        private readonly BlockingCollection<string> _buffer
            = new BlockingCollection<string>(boundedCapacity: 10);
        public Task Start()
        {
            while (true)
            {
                var newData = await _filesReader.GetData();
                _buffer.Add(newData); // will block until _buffer
                                      // has less than 10 items.
            }
        }
    }
