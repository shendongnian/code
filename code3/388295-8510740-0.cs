    using System;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                // let's make a pseudo-random long string
                var longString = new StringBuilder("abcdefghijklmnopqrstuvwxyz0123456789");
                var r = new Random((int) DateTime.Now.Ticks);
    
                for (int i = 0; longString.Length < 256; i++)
                {
                    longString.Insert(r.Next(0, longString.Length - 1)
                                      , (!(Math.IEEERemainder(i, 3) < 0.5)
                                             ? longString[i].ToString().ToUpper()
                                             : longString[i].ToString()));
                }
    
                
                // Let's see what our long string looks like...
                Console.WriteLine(longString);
    
                // Now, let's display the first 50 characters of our long string
                // followed by "..." to indicate that there is more.
                var shortstring = String.Format("{0}...",longString.ToString().Substring(0, 50));
                Console.WriteLine(shortstring);
                
                //Wait for user to hit a key while results are reviewed.
                Console.ReadKey();
            }
        }
    }
