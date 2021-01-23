    unsafe static void Main(string[] args)
    {
      fixed (byte* arg0 = Encoding.ASCII.GetBytes(args[0]), 
                   arg1 = Encoding.ASCII.GetBytes(args[1]), 
                   arg2 = Encoding.ASCII.GetBytes(args[2]))
      {
        byte*[] arr = { arg0, arg1, arg2 };
    
        fixed (byte** argv = arr)
        {
          ...
        }
      }
    }
