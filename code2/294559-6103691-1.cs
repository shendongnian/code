     public string Get8Digits()
     {
       var bytes = new byte[4];
       var rng = RandomNumberGenerator.Create();
       rng.GetBytes(bytes);
       uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
       return String.Format("{0:D8}", random);
     }
