    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        struct QA { public string Q, A; }
        static Random _r = new Random();        
        static int Quiz()
        {
            var QAndA = new QA[] {
                new QA { Q = "What is the capital of France"  , A = "Paris"}, 
                new QA { Q = "What is the capital of Spain"   , A = "Madrid"}, 
                //  ...
                new QA { Q = "What is the captial of Russia"  , A = "Moscow"}, 
                new QA { Q = "What is the capital of Ukraine" , A = "Kiev"}, 
            };
            foreach (var qa in QAndA.OrderBy(i => _r.Next()))
            {
                Question(qa.Q, qa.A);
            }
            return 0;
        }
        public static void Main(string[] args)
        {
            int n = Quiz();
        }
        private static void Question(string q, string a)
        {
            Console.WriteLine("Q. {0}", q);
            Console.WriteLine("A. {0}", a);
        }
    }
