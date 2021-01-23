    static void Main(string[] args)
            {
                FileStream fs = File.Create("D:\\ror.txt");
                ManualResetEvent evt = new ManualResetEvent(false);
                AsyncFileWriter writer = new AsyncFileWriter(fs, () =>
                                                                     {
                                                                         Console.Write("Write Finished");
                                                                         evt.Set();
                                                                     }
    
                    );
                byte[] bytes = File.ReadAllBytes("D:\\test.xml");//Getting some random bytes
    
                writer.Write(bytes);
                evt.WaitOne();
                Console.Write("Write Done");
            }
