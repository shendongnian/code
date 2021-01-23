    static void Main(string[] args)
        {           
            //
            //// SEND - RECEIVE:
            //
            SendingData();
            Console.ReadLine();
        }
        private static void SendingData()
        {
            int[] commands = { 1, 2, 3 }; 
            // 1 - user text
            // 2 - new game
            // 3 - join game
            // ...
            for (int i = 0; i < commands.Length; i++)
            {
                //convert to byte[]
                byte[] allBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    // 1.st - write a command:
                    ms.Write(BitConverter.GetBytes(commands[i]), 0, 4);
                    // 2nd - write a text:                                         
                    if (commands[i] == 1)
                    {
                        //some example text (like that user sends it):
                        string myText = "This is some text at command " + commands[i];
                        byte[] myBytes = Encoding.UTF8.GetBytes(myText);
                        ms.Write(myBytes, 0, myBytes.Length);
                    }
                    allBytes = ms.ToArray();
                }
                //convert back:
                int valueA = 0;
                StringBuilder sb = new StringBuilder();
                foreach (var b in ReadingData(allBytes).Select((a, b) => new { Value = a, Index = b }))
                {
                    if (b.Index == 0)
                    {
                        valueA = BitConverter.ToInt32(b.Value, 0);
                    }
                    else
                    {
                        sb.Append(Convert.ToChar(b.Value[0]));
                    }
                }
                if (sb.ToString().Length == 0)
                    sb.Append("ONLY COMMAND");
                Console.WriteLine("Command = {0} and Text is \"{1}\".", valueA, sb.ToString());
            }            
        }
        private static IEnumerable<byte[]> ReadingData(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    int j = 0;
                    byte[] buffer = new byte[4];
                    for (int i = 0; i < data.Length; i++)
                    {
                        buffer[j++] = data[i];
                        if (i == 3) //SENDING COMMAND DATA
                        {
                            yield return buffer;
                            buffer = new byte[1];
                            j = 0;
                        }
                        else if (i > 3) //SENDING TEXT
                        {
                            yield return buffer;
                            j = 0;
                        }
                    }
                }
            }
        }
