    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp25
    {
        [System.Serializable]
        public class NMSG_UpdatePlayer : NMSG
        {
            public NMSG_UpdatePlayer() : base(0)
            { }
            public float posX;
            public float posY;
    
            public float rotZ;
    
            public float health;
            public float shield;
    
            public int connectionId;
        }
        [System.Serializable]
        public abstract class NMSG
        {
    
            private byte? discriminator = null;
            public NMSG(byte discriminator) { this.discriminator = discriminator; }
        }
    
    
        class Program
        {
            public static void sendToServer(NMSG msg, int channelId)
            {
    
                int BYTE_SIZE = 1024;
    
                byte[] buffer = new byte[BYTE_SIZE];
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(buffer);
                formatter.Serialize(ms, msg); //error occur here.
    
                
            }
            static void Main(string[] args)
            {
                var o = new NMSG_UpdatePlayer();
                sendToServer(o, 0);
    
                Console.ReadKey();
    
            }
        }
    }
