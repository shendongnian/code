    class Program
    {
       public static void Main(string[] args)
       {
          Type voidType = typeof(Program).GetMethod("Main").ReturnType;
       }
    }
