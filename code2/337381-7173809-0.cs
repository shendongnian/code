    using System;
    using System.IO;
    namespace Stream
    {
      class Program
      {
        static void Main (string [] args)
        {
          float
            f = 1;
      
          int
            i;
          MemoryStream
            s = new MemoryStream ();
          BinaryWriter
            w = new BinaryWriter (s);
          w.Write (f);
          s.Position = 0;
          BinaryReader
            r = new BinaryReader (s);
          i = r.ReadInt32 ();
      
          s.Close ();
          Console.WriteLine ("Float " + f + " = int " + i);
        }
      }
    }
