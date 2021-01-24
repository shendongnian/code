            double d = 100.2;
            char[] xx = d.ToString().ToCharArray();
            Console.WriteLine($" Type of xxx is {xx.GetType()}");
            Console.WriteLine($"Length : {xx.Length}");
            Console.WriteLine($"Items : ");
            foreach (char c in xx)
                Console.WriteLine(c);
            Console.ReadLine();
It seems that you mean a byte array in your case. Try this: `Encoding.GetEncoding("UTF-8").GetBytes(xx);`
