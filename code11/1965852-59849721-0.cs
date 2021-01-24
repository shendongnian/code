    using System;
    using System.Collections.Generic;
    public class Program
    {
	  public static void Main(string[] args)
	  {
		List<int> todlers = new List<int>();
        List<int> children = new List<int>();
        List<int> grownups = new List<int>();
		int input = 0;
        do
        {
            Console.Write("Give a number (0 = stop) : ");
            input = int.Parse(Console.ReadLine());
            if (todlers.Count < 10 && input < 5 && input > 0)
            {
                todlers.Add(input);
            }
            else if (children.Count < 10 && input > 4 && input < 18)
            {
                children.Add(input);
            }
            else if (grownups.Count < 10 && input > 17)
            {
                grownups.Add(input);
            }
        }while(input>0);
        Console.Write("\n");
        Console.WriteLine("TODLERS");
        for (int i = 0; i < todlers.Count; i++)
        {
            Console.WriteLine("Todler {0} is {1} years old", i+1, todlers[i]);
        }
        Console.Write("\n");
        Console.WriteLine("CHILDREN");
        for (int i = 0; i < children.Count; i++)
        {
            Console.WriteLine("Child {0} is {1} years old", i+1, children[i]);
        }
        Console.Write("\n");
        Console.WriteLine("GROWNUPS");
        for (int i = 0; i < grownups.Count; i++)
        {
            Console.WriteLine("Man/Woman {0} is {1} years old", i+1, grownups[i]);
        }
        Console.ReadKey();
	  }
    }
