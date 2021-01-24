    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>(Enumerable.Range(1, 300));
            foreach (var placeInQueue in queue)
            {
                if(placeInQueue <= 1)
                    Console.WriteLine($"Place: {placeInQueue}. Very soon!");
                else if(placeInQueue < 300)
                {
                    var fromTo = GetFromTo(placeInQueue);
                    Console.WriteLine($"Place: {placeInQueue}. From {fromTo.Item1} to {fromTo.Item2} weeks.");
                }
            }
        }
        
        private static Tuple<int,int> GetFromTo(int place)
        {
            if (place < 5)
                return new Tuple<int, int>(0, 1);
    
            var q1 = place / 5;
            var q2 = 0;
            if((place + 1) % 6 == 0)
            {
                q2 = (place + 1) / 6;
                q1 = int.MaxValue;
            }
            else
                q2 = (place/6) == 0 ? q1 : (place/6);
    
            var from = Math.Min(q1, q2);
            var to = from + 1;
            return new Tuple<int, int>(from, to);
        }
    }
