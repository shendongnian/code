    public class Server {
         
         public void StartAcceptingConnections() {
              
              while(true) {
                  // accept socket connection
                  // read new user name
                  foreach(Client cl in connectedClients) {
                      // send new user name to cl.Socket
                  }    
              }             
         }
    }
