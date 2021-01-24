    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
                        
    public class Program
    {
        public void Main()
        {
            var examples = new List<Example>();
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var newPosition = rnd.NextDouble();
                examples.Add(new Example { Position = newPosition });
            }
            examples.GroupBy(x => Math.Round( x.Position,2)).Dump();
            
            
            examples.GroupBy(x => x => Math.Round(x.Position / 0.05)).Dump();
        }
        public class Example
        {
            public double Position { get; set; }
        }
    }
    
