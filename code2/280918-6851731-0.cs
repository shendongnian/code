    byte[] m_LongBuffer;
    byte[] m_SmallBuffer;
    void ReceiveCallback(IAsyncResult iar)
    {
       //m_SmallBuffer contains the data read from the stream
       //Append it to m_LongBuffer
       int bytesread = socket.EndReceive(iar);
       m_LongBuffer = m_LongBuffer.Concat(m_SmallBuffer.Take(bytesread)).ToArray();
       int startpoint = 0;
       int splitpoint = 0;
       int lastendpoint = 0;
       bool twochar = false;
       do
       {
           for(int i=0;i<m_LongBuffer.Length;++i)
           {
               if((m_LongBuffer[i] == 0x0A) || (m_LongBuffer[i] == 0x0D))
               {
                   splitpoint = i;
                   if((m_LongBuffer[i+1] == 0x0A) || (m_LongBuffer[i+1] == 0x0D))
                        twochar=true;
                   else
                        twochar=false;
                   
                   lastendpoint = splitpoint;                   
                   String message = ASCII.ASCIIEncoding.GetString(m_LongBuffer.Skip(startpoint).Take(splitpoint - startpoint).ToArray());
                   //Do something with the message
                   startpoint = splitpoint + (twochar ? 2 : 1);
                   break;
               }
           }
           if(i >= m_LongBuffer.Length)
                splitpoint = -1;
       } while (splitpoint != -1);
       m_LongBuffer = m_LongBuffer.Skip(lastendpoint).ToArray();
    }
