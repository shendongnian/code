    using System;
    using System.IO;
    using System.Security.Cryptography;
    
    class FileComparer
    {
        static void Compare()
        {
            // Create the hashing object.
            using (HashAlgorithm hashAlg = HashAlgorithm.Create())
            {
                using (FileStream fsA = new FileStream("c:\\test.txt", FileMode.Open),
                    fsB = new FileStream("c:\\test1.txt", FileMode.Open)){
                    // Calculate the hash for the files.
                    byte[] hashBytesA = hashAlg.ComputeHash(fsA);
                    byte[] hashBytesB = hashAlg.ComputeHash(fsB);
    
                    // Compare the hashes.
                    if (BitConverter.ToString(hashBytesA) == BitConverter.ToString(hashBytesB))
                    {
                        Console.WriteLine("Files match.");
                    } else {
                        Console.WriteLine("No match.");
                    }
                }
            }
        }
    }
