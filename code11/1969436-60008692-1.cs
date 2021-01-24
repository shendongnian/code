using System;
namespace code
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Ask me anything!");
         string userQuestion = Console.ReadLine();
         string areYouABot = "I am not!";
         if (userQuestion == "Are you a bot?")
         {
            Console.WriteLine(areYouABot);
         }
      }
   } 
}
 1. Put your class in your namespace.
 2. If statements need booleans so change `=` to `==`
 3. You don't put semicolons after if statements (or any loops) for the same reason you don't put one after namespace, class, or Main. They all are "wrapping" something instead of "doing" something. The exception being if the (if/loop) statement is "wrapping" only a single line. Ex. `if (userQuestion == "Are you a bot?") Console.WriteLine(areYouABot);`
If you would like any more explanation on any of these, let me know in a comment below.
Edited to include comments below.
