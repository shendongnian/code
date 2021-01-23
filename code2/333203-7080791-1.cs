    public class SerialTalk{
    SerialPort s;    
    Queue<string> RecQueue=new Queue<string>();
    //...bunch of irrelevant stuff here (ctors etc)
    string innerBuffer = ""; //a buffer we keep in between DataReceiveHandlers for the portion of text not newlined yet
    private void DataReceivedHandler(Object sender, object e)
    {
        byte[] recv;
               
        lock (s_lock)
        {
            int bytes = s.BytesToRead;
            recv = new byte[bytes];
            s.Read(recv, 0, bytes);
        }
        innerBuffer += System.Text.Encoding.GetEncoding("utf-8").GetString(recv).Replace("\r\n","\n"); //could be enhanced using stringbuilder.
        string[] lines = innerBuffer.Split('\n'); 
        innerBuffer = lines[lines.Length-1];  //always keep the portion after the last newline in the buffer
        Console.Write(recv);
        lock (RecQueue)
        {
            for(int x=0;x<innerBuffer.Length-2;x++) //-2 here instead of -1 as you don't want to send the remainder of the inner buffer until the next newline
                RecQueue.Enqueue(lines[x]);
        }
    }
    }
