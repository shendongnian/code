    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    namespace ConsoleApplication1
    {
        public class ColorResult
        {
            public int Index;
            public string Name;
            public float Prob;
            public ColorResult(int Index, string Name, float Prob)
            {
                this.Index = Index;
                this.Name = Name;
                this.Prob = Prob;
            }
            public override string ToString()
            {
                return Index.ToString() + ", " + Name + ", " + Prob.ToString();
            }
        }
        class Program
        {
            public static void Main()
            {
                List<ColorResult> Colors = new List<ColorResult>();
                
                Colors.Add(new ColorResult(1, "Unknown", 5f));
                Colors.Add(new ColorResult(2, "Blue", 80f));
                Colors.Add(new ColorResult(3, "Blue", 80f));
                Colors.Add(new ColorResult(4, "Green", 40f));
                Colors.Add(new ColorResult(5, "Blue", 80f));
                Colors.Add(new ColorResult(6, "Blue", 80f)); 
                Colors.Add(new ColorResult(7, "Red", 20f)); 
                Colors.Add(new ColorResult(8, "Blue", 80f));   
                Colors.Add(new ColorResult(9, "Green", 5f));
                var test1 = from i in Enumerable.Range(0, Colors.Count)
                            select (i < Colors.Count - 2 &&
                                   (Colors[i].Prob < 60f) &&
                                   (Colors[i + 1].Name == Colors[i + 2].Name) &&
                                   (Colors[i+1].Prob > 60f) &&
                                   (Colors[i+2].Prob > 60f)) ?
                            new ColorResult(1, Colors[i + 1].Name, Colors[i].Prob) :
                            Colors[i];
            }
        }
    }
