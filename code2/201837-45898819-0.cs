            double e = 1.5;
            double d = e;
            object o1 = d;
            object o2 = d;
            Console.WriteLine(o1.Equals(o2)); // Ture
            Console.WriteLine(Object.Equals(o1, o2)); // Ture
            Console.WriteLine(Object.ReferenceEquals(o1, o2)); // False
            Console.WriteLine(e.Equals(d)); // Ture
            Console.WriteLine(Object.Equals(e, d)); // Ture
            Console.WriteLine(Object.ReferenceEquals(e, d)); // False
