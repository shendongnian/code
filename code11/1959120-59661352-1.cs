      while (mmInStream.CanRead)
       {
           try
           {
               mmInStream.Read(myReadBuffer, 0, myReadBuffer.Length);
               _output.Write(myReadBuffer, 0, myReadBuffer.Length);
           }
           catch (System.IO.IOException ex)
           {
               System.Diagnostics.Debug.WriteLine("Input stream was disconnected", ex);
           }
           Sleep(x) --- calculate the x millisecond/second based on the buffer size & sampling frequency.
       }
 
