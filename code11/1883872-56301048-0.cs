    var key = Encoding.UTF8.GetBytes("mysmallkey");
      //myAes.Key = Key; //ERROR
       KeySizes[] ks = myAes.LegalKeySizes;
       foreach (KeySizes item in ks)
       {
        Console.WriteLine("\tLegal min key size = " + item.MinSize);
        Console.WriteLine("\tLegal max key size = " + item.MaxSize);
        //Output
        // Legal min key size = 128
        // Legal max key size = 256
       }
