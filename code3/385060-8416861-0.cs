            var s = "123.34";
            decimal d;
            bool isDec = Decimal.TryParse(s, out d);
            if (isDec)
                Console.WriteLine("It was a decimal: " + d);
            else
                Console.WriteLine("Not a decimal!");
            Console.WriteLine(isDec);
            Console.ReadLine();
