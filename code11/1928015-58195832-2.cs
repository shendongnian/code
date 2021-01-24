    public class CommandDataPacket
     {
     public byte Head
     {
      get
       {
       return 0xA0;
       }
      }
    
      public byte Length
      {
       get
        {
        return Data.Length + 3;
        }
       }
    
      public byte Address {get;set;}
    
      public byte Command {get;set;}
    
      public byte[] Data {get;set;} = new byte[0];
    
      public cyte Check
      {
       get
        {
         // did not find anything how to calculate the check Byte. You'll have to implement it
        }
       }
    
      public byte[] ToBytes()
       {
       List<byte> result = new List<byte>();
       result.Add(Head);
       result.Add(Length);
       result.Add(Address);
       result.Add(Command);
       result.AddRange(Data);
       result.Add(Check);
       return result.ToArray();
       }
     }
