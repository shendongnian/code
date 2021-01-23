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
        // Iterate through the list remembering the last two elements
        // to implement rule 1
        public static IEnumerable<ColorResult> Rule1(IEnumerable<ColorResult> input)
        {
          ColorResult last2 = null;
          ColorResult last1 = null;
          foreach (var color in input)
          {
            if ((color.Prob < 60f)
                && (last1 != null) && (last1.Prob >= 60f)
                && (last2 != null) && (last2.Prob >= 60f)
                && (last2.Name == last1.Name))
            {
              color.Name = last2.Name;
            }
            yield return color;
            last2 = last1;
            last1 = color;
          }
        }
        // Iterate through the list with two element look-ahead
        // to implement rule 3
        public static IEnumerable<ColorResult> Rule3(IEnumerable<ColorResult> input)
        {
          ColorResult color = null;
          ColorResult ahead1 = null;
          foreach (var ahead2 in input)
          {
            if ((color != null) && (color.Prob < 60f)
                && (ahead1 != null) && (ahead1.Prob >= 60f)
                && (ahead2 != null) && (ahead2.Prob >= 60f)
                && (ahead1.Name == ahead2.Name))
            {
              color.Name = ahead1.Name;
            }
            yield return color;
            color = ahead1;
            ahead1 = ahead2;
          }
          // Using a null check here as a cheat way to test we've
          // actually had two inputs.
          // NB Will not preserve trailing nulls in the list;
          // you'll need to count inputs if you need that.
          if (color != null) yield return color;
          if (ahead1 != null) yield return ahead1;
        }
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
          var processed = Rule3(Rule1(Colors));
          foreach (var color in processed)
          {
            Console.WriteLine(color);
          }
        }
      }
    }
