    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.IO;
    using System.Collections.Concurrent;
    
    class ProducerConsumerApp : IDisposable
    {
        public static int blockSize = 15;
    
        const int maxQueueSize = 4;  // max allowed number of objects in the queue
    
        BlockingCollection<byte[]> _queue = new BlockingCollection<byte[]>(maxQueueSize);
        private Thread _consumerThread;
    
        public ProducerConsumerApp(Stream outputStream)
        {
            _consumerThread = new Thread(dequeueObjectAndWriteItToFile);
            _consumerThread.Start(outputStream);
        }
    
        public void enqueueObject(byte[] data)
        {
            _queue.Add(data);
        }
    
        public void Dispose()  // called automatically (IDisposable implementer) when instance is being destroyed
        {
            enqueueObject(null);                         // Signal the consumer to exit.
            _consumerThread.Join();                     // Wait for the consumer's thread to finish.
        }
    
        void dequeueObjectAndWriteItToFile(object outputStream)
        {
            var outStream = (FileStream)outputStream;
            while (true)
            {
                var data = _queue.Take();
                if (data == null)
                {
                    outStream.Close();
                    // Console.WriteLine("Data file reading finished => let consumerThread finish and then quit the app");
                    return;
                }
                outStream.Write(data, 0, data.Length); // write data from the queue to a file
            }
        }
    
        static void Main()
        {
            var originalFilePath = @"c:\temp\test.txt";
            var outputFilePath = @"c:\temp\test_out.txt";
    
            FileInfo originalFile = new FileInfo(originalFilePath);
            byte[] data = new byte[blockSize];
            int bytesRead;
    
            using (FileStream originalFileStream = originalFile.OpenRead())    // file input stream
            using (FileStream fileOutputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            using (ProducerConsumerApp q = new ProducerConsumerApp(fileOutputStream))
            {
                while ((bytesRead = originalFileStream.Read(data, 0, blockSize)) > 0)   // reads blocks of data from a file
                {
                    // test - in case of a text file:
                    //string str = System.Text.Encoding.Default.GetString(data);
                    //Console.WriteLine("data block read from a file:" + str);
    
                    if (bytesRead < data.Length)
                    {
                        byte[] data2 = new byte[bytesRead];
                        Array.Copy(data, data2, bytesRead);
                        data = data2;
                    }
    
                    q.enqueueObject(data);   // put the data into the queue
    
                    data = new byte[blockSize];
                }
            }
            // because of "using" the Dispose method is going to be called in the end which will call enqueueObject(null) resulting in stopping the consumer thread
    
            Console.WriteLine("Finish");
        }
    }
