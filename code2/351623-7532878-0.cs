            static void Main(string[] args)
            {
    
                int[] responseBuffer = { 0, 1, 2, 3, 4, 5 };
                List<UInt64> bufferList = new List<ulong>();
                foreach (var r in responseBuffer)
                    bufferList.Add((UInt64)r);
    
                UInt64[] m_buffer = bufferList.ToArray();
                foreach (var item in m_buffer)
                    Console.WriteLine(item);
    
                //string m_s = "";
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < m_buffer.Length; k++)
                {
                    int value = (int)m_buffer[k];
                    for (int i = 7; i >= 0; i--)
                    {
                        if ((value >> i & 0x1) > 0)
                        {
                            sb.Append("1");
                            value &= (Byte)~(0x1 << i);
                        }
                        else
                            sb.Append("0");
                    }
                    sb.Append(" ");
                }
                Console.WriteLine(sb.ToString());
           }
