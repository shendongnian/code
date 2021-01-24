    byte[] package= {255,13,45,56};
    //The byte array that will be used to calculate CRC32C hex
        
    foreach (byte b in package)
    {
    Console.WriteLine("0x{0:X}", b);
    //Writing the elements in hex format to provide visibility (for testing)
    //Take note that "0x{0:X}" part is used for hex formatting of a string. X can be changed depending on the context eg. x2, x8 etc.
    }
    Console.WriteLine("-");//Divider
    /* Actual solution part */                
    String crc = String.Format("0x{0:X}", Crc32CAlgorithm.Compute(inner));
    /* Actual solution part */ 
    Console.WriteLine(crc);
    /* Output: 0x6627634B */
    /*Using CRC32.NET NuGet package for Crc32CAlgorithm class. 
    Then calling Compute method statically and passing byte array to the method. Keep in mind it returns uint type value. Then writing the returned variable in hex format as described earlier. */
