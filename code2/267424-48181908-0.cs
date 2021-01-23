     static void Main()
         {
                 for (int i=0; i<GetNames().Length; i++)
                   {
                        Console.WriteLine (GetNames()[i]);
                    }
         }
      static string[] GetNames()
       {
             string[] ret = {"Answer", "by", "Anonymous", "Pakistani"};
             return ret;
       }
