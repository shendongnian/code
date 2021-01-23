    using System;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                byte[] b1 = { 1, 2, 4, 8, 16, 32 };
                byte[] b2 = new byte[6];
    
                FileStream f1;
                f1 = new FileStream("test.txt", FileMode.Create, FileAccess.Write);
    
                // write the byte array into a new file
                f1.Write(b1,0,6);
                f1.Close();
    
                f1 = new FileStream("test.txt", FileMode.Open, FileAccess.Read);
    
                // read the byte array
                f1.Read(b2, 0, 6);
    
                // make changes to the byte array
                for (int i = 1; i < b2.Length; i++) 
                { 
                      b2[i] = (byte)(b2[i] << (byte)10);
                }
    
                f1.Close();
    
                f1 = new FileStream("test.txt", FileMode.Create, FileAccess.Write);
    
                // write the new byte array into the file
                f1.Write(b2,0,6);
                f1.Close();
            }
        }
    }
