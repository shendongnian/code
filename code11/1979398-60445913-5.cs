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
    
            class Person
            {
                public long Id { get; set; }
                public String Name { get; set; }
    
                public byte[] ToBytes()
                {
                    //this is aproach example, Needs more improvements
                    return BitConverter.GetBytes(Id).Concat(Encoding.UTF8.GetBytes(Name).Take(Settings.blockSize - 8/* long type size of Id */)).ToArray(); //byte[] of blockSize size
                }
    
                public static Person ToPerson(byte[] bytes)
                {
                    return new Person
                    {
                        Id = BitConverter.ToInt64(bytes.Take(8).ToArray()),
                        Name = Encoding.UTF8.GetString(bytes.Skip(8).ToArray())
                    };
                }
            }
            static void Main(string[] args)
            {
                //EXAMPLE 1
                CompressingProducer<string> producer = new CompressingProducer<string>();
                using (Stream filestream = File.OpenRead("path to file"))
                {
                    //ProduceData(Stream fileInputStream, Func<byte[], string> convert), T now is string type.
                    producer.ProduceData(filestream, data => Encoding.UTF8.GetString(data));//Using lambda expression. 
                    producer.ProduceData(filestream, ConvertData);//Using delegate. //Same result as lambda.
                }
    
                //EXAMPLE 2
                CompressingProducer<Person> personProducer = new CompressingProducer<Person>();
                using (Stream filestream = File.OpenRead("path to file containing Person Blocks"))
                {
                    //ProduceData(Stream fileInputStream, Func<byte[], Person> convert), T now is Person type.
                    personProducer.ProduceData(filestream, data => Person.ToPerson(data));//Using lambda expression. 
                }
                
                Console.ReadLine();
            }
        }
