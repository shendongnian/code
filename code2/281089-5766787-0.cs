     [DllImport("user32.dll")]//This is where you identify your dll...
       public static extern int MessageBoxA(  //This would be an object from your dll
          int h, string m, string c, int type);
    
       public static int Main() 
       {
          return MessageBoxA(0, "Hello World!", "My Message Box", 0);
       }
