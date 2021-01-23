      class Program
      {
        static BlockingStream _dataStream = new BlockingStream(10);
        static Random _rnd = new Random();
        [STAThread]
        static void Main(string[] args)
        {
          Task producer = new Task(() =>
            {
              Thread.Sleep(1000);
              for (int i = 0; i < 100; ++i)
              {
                _dataStream.WriteByte((byte)_rnd.Next(0, 255));            
              }          
            });
    
          Task consumer = new Task(() =>
            {
              int i = 0;
              while (true)
              {
                Console.WriteLine("{0} \t-\t {1}",_dataStream.ReadByte(), i++);
                // Slow the consumer down.
                Thread.Sleep(500);
              }
            });
    
          producer.Start();
          consumer.Start();
          
          Console.ReadKey();
        }
