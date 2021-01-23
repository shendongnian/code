    using System;
    using System.IO;
    
    static public void Main ()
    {
        FileStream ostrm;
        StreamWriter writer;
        TextWriter oldOut = Console.Out;
        try
        {
            ostrm = new FileStream ("./Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
            writer = new StreamWriter (ostrm);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Cannot open Redirect.txt for writing");
            Console.WriteLine (e.Message);
            return;
        }
        Console.SetOut (writer);
        Console.WriteLine ("This is a line of text");
        Console.WriteLine ("Everything written to Console.Write() or");
        Console.WriteLine ("Console.WriteLine() will be written to a file");
        Console.SetOut (oldOut);
        writer.Close();
        ostrm.Close();
        Console.WriteLine ("Done");
    }
