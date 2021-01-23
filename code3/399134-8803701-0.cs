    public class PipeServer {
   
    void ListenForClients() {
    //Some code
    Thread readThread = new Thread(Read) { IsBackground = true  };
    }
    void Read(object clientObj) {
    //Some Code
    MessageReceived(ms.ToArray());
     }
    void MessageReceived(byte[] message){
  
      //Do Job
    }
    }
