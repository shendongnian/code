    public class RobotData
    {
       ...
    
       public byte[] ToArray()
       {
          using (var ms = new MemoryStream())
             using (var sw = new BinaryWriter(ms))
             {
                sw.Write(messageType);
                sw.Write(axisCount);
                sw.Write(statusDWord);
    
                foreach (var data in axData)
                {
                   sw.Write(data.axisId);
                   sw.Write(data.position);
                   ...
                }
    
                return ms.ToArray();
             }
       }
    }
