    class CompressingProducer<T>
    {
    
        Queue<T> _queue;
    
        public void ProduceData(Stream fileInputStream, Func<byte[], T> convert)
        {
            byte[] block = new byte[Settings.blockSize];
            int bytesRead;
    
            while ((bytesRead = ((Stream)fileInputStream).Read(block, 0, Settings.blockSize)) > 0)
            {
                EnqueueObject(convert(block));//Using convert function, from byte[] ==> to T 
                block = new byte[Settings.blockSize];
            }
        }
    
        private void EnqueueObject(T data)
        {
            _queue.Enqueue(data);
        }
    }
    
    
    class Program
    {
        public static string ConvertData(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }
    
        static void Main(string[] args)
        {
            CompressingProducer<string> producer = new CompressingProducer<string>();
            using (Stream filestream = File.OpenRead("path to file"))
            {
                //ProduceData(Stream fileInputStream, Func<byte[], string> convert), T now is string type.
                producer.ProduceData(filestream, data => Encoding.UTF8.GetString(data));//Using lambda expression. 
                producer.ProduceData(filestream, ConvertData);//Using delegate. //Same result as lambda.
            }
    
            Console.ReadLine();
        }
    }
