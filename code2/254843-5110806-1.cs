    using System;
    using System.Runtime.InteropServices;
    class MainClass 
    {
       [DllImport("User32.dll")]
       public static extern int MessageBox(int h, string m, string c, int type);
    
       static int Main() 
       {
          string myString; 
          Console.Write("Enter your message: ");
          myString = Console.ReadLine();
          return MessageBox(0, myString, "My Message Box", 0);
       }
    }
