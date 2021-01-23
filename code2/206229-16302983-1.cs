            Mathos.Parser.MathParser parser = new Mathos.Parser.MathParser();
            string expr = "(x+(2*x)/(1-x))"; // the expression
            decimal result = 0; // the storage of the result
            parser.LocalVariables.Add("x", 41); // 41 is the value of x
            result = parser.Parse(expr); // parsing
            Console.WriteLine(result); // 38.95
