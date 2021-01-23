    using System;
    using System.Security.Cryptography;
    
    class Test
    {
        static void Main()
        {
            var rng = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[6];
            rng.GetBytes(randomBytes);
            
            byte[] guidBytes = new byte[16];
            Buffer.BlockCopy(randomBytes, 0, guidBytes, 10, 6);
            
            Guid guid = new Guid(guidBytes);
            Console.WriteLine(guid);
        }
    }
