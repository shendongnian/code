    class PropertyTest
    {
        public int field = 0;
        public int Property { get; set; }
    }
        private void PropertyChangeTime()
        {
            int counter = 0;
            var instance = new PropertyTest();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 100000000; i++)
            {
                instance.field = counter++;
            }
            watch.Stop();
            var elapsedMsField = watch.ElapsedMilliseconds;
            counter = 0;
            watch.Reset();
            watch.Start();
            for (int i = 0; i < 100000000; i++)
            {
                instance.Property = counter++;
            }
            watch.Stop();
            var elapsedMsProperty = watch.ElapsedMilliseconds;
            Console.WriteLine($"field: {elapsedMsField}\nproperty: {elapsedMsProperty}");
        }
