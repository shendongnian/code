    using System;
    using System.Collections.Generic;
                        
    public class Program
    {
        // This is a list of all your previous numbers
        // this could come from database or calculated somewhere in your application
        private static List<int> numbersList = new List<int>(); 
        public static void Main()
        {
            string NumberOfLoadingList; 
            
            for(var i=0; i<10; i++)
            {
                NumberOfLoadingList = string.Format("{0}/{1:0000}/{2}", DateTime.Now.ToString("MM"), GenerateNewNumber(), DateTime.Now.ToString("yy"));
                Console.WriteLine(NumberOfLoadingList);
            }
        }
        private static int GenerateNewNumber()
        {
            int number = 0;
            
            while(true) 
            {
                if (!numbersList.Contains(++number)) 
                {
                    numbersList.Add(number);
                    return number;
                }
                
            }
        }
    }
