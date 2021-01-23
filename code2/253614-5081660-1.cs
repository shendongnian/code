    public class SendPic
    {
        private object lockobj = new object();
        // .... whatever other code ...
        public void send()
        {
           // .... whatever previous code ...
           lock(lockobj)
           {
              // assuming that the sd dictionary already has the relevant key
              // otherwise you'd need to do a Form1.sd.Add(key, byteArray)
              Form1.sd["/" + myName + "/video"] = byteArray;
           }
           // .... whatever following code ...
        }
    } 
