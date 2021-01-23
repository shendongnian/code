    class ConsumerSettings
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    class Consumer1
    {
        public Consumer1(ConsumerSettings settings)
        {
            if (settings.Property1 == "foo")
            {
            }
        }
    }
    class Consumer2
    {
        public Consumer2(ConsumerSettings settings)
        {
            if (settings.Property2 == "bar")
            {
            }
        }
    }
