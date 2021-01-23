    using System;
    using System.Collections.Generic;
    
    namespace ActionableList
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Actionable> actionables = new List<Actionable>
                {
                    new Actionable
                        {
                            Key = ConsoleKey.UpArrow,
                            Action = ConsoleKeyActions.UpArrow
                        },
                    new Actionable
                    {
                        Key = ConsoleKey.DownArrow,
                        Action = ConsoleKeyActions.DownArrow
                    },
                    new Actionable
                    {
                        Key = ConsoleKey.RightArrow,
                        Action = ConsoleKeyActions.RightArrow
                    },
                    new Actionable
                    {
                        Key = ConsoleKey.UpArrow,
                        Action = ConsoleKeyActions.UpArrow
                    }
                };
    
                actionables.ForEach(a => a.Action());
                
                Console.ReadLine();
            }
        }
    
        public class Actionable
        {
            public ConsoleKey Key { get; set; }
            public Action Action { get; set; }
        }
    
        public static class ConsoleKeyActions
        {
            public static void UpArrow()
            {
                Console.WriteLine("Up Arrow.");
            }
    
            public static void DownArrow()
            {
                Console.WriteLine("Down Arrow.");
            }
    
            public static void LeftArrow()
            {
                Console.WriteLine("Left Arrow.");
            }
    
            public static void RightArrow()
            {
                Console.WriteLine("Right Arrow.");
            }
        }
    }
