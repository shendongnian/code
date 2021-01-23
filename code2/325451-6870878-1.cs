    using System;
    using System.Net.Sockets;
    
    //we derive our class from a standart one
    
    public class WOLClass:UdpClient    
    {
        public WOLClass():base()
        { }
        //this is needed to send broadcast packet
    
        public void SetClientToBrodcastMode()    
        {
          if(this.Active)
           this.Client.SetSocketOption(SocketOptionLevel.Socket,
                                     SocketOptionName.Broadcast,0);
        }
     }    
    
    private void WakeFunction(string MAC_ADDRESS)   
         {
              WOLClass client=new WOLClass();
              client.Connect(new 
                 IPAddress(0xffffffff),  //255.255.255.255  i.e broadcast
        
                 0x2fff); // port=12287 let's use this one 
        
              client.SetClientToBrodcastMode();
              //set sending bites
        
              int counter=0;
              //buffer to be send
        
              byte[] bytes=new byte[1024];   // more than enough :-)
        
             //first 6 bytes should be 0xFF
        
             for(int y=0;y<6;y++)
                bytes[counter++]=0xFF;
             //now repeate MAC 16 times
        
             for(int y=0;y<16;y++)
             {
                 int i=0;
                 for(int z=0;z<6;z++)
                 {
                      bytes[counter++]= 
                          byte.Parse(MAC_ADDRESS.Substring(i,2),
                          NumberStyles.HexNumber);
                      i+=2;
                 }
             }
        
             //now send wake up packet
        
             int reterned_value=client.Send(bytes,1024);
         }
