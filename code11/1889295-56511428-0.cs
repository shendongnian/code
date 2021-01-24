    class Calculator
    {
        public Stack<double> result = new Stack<double>();
        double total;
        public void add(double a, double b)
        {
            total = a + b;
            Console.WriteLine("Sum:{0}", total);
            result.Push(total);
        }
        public void sub(double a, double b)
        {
            total = a - b;
            Console.WriteLine("Difference:{0}", total);
            result.Push(total);
        }
        public void mul(double a, double b)
        {
            total = a * b;
            Console.WriteLine("Product:{0} ", total);
            result.Push(total);
        }
        public void div(double a, double b)
        {
            if (b != 0)
            {
                total = a / b;
                Console.WriteLine("Quotient:{0}", total);
                result.Push(total);
            }
            else
            {
                Console.WriteLine("Error: Cannot divide by 0");
            }
        }
        double getTotal()
        {
            return total;
        }
        void undo()
        {
            if (result.Count == 0)
            {
                Console.WriteLine("UNDO IS NOT AVAILABLE");
            }
            result.Pop();
            total = result.Pop();
            Console.WriteLine("Running total:{0}", total);
        }
        void clear()
        {
            while (result.Count != 0)
                result.Pop();
            total = 0;
            Console.WriteLine("Running total:{0}", total);
        }
        static int Main()
        {
            Calculator cal = new Calculator();
            string line = "";
            while (true)
            {
                Console.WriteLine("Enter (Clear, Undo, Exit, Expression):");
                line = Console.ReadLine();
                if (line.ToLower() == "exit")
                    break;
                else if (line.ToLower() == "undo")
                    cal.undo();
                else if (line.ToLower() == "clear")
                    cal.clear();
                else
                {
                    double a, b;
                    char c;
                    Console.WriteLine("Write the first number");
                    double.TryParse(Console.ReadLine(), out a);
                    Console.WriteLine("Write the second number");
                    double.TryParse(Console.ReadLine(), out b);
                    Console.WriteLine("Write the operand (+,-,/,*)");
                    char.TryParse(Console.ReadLine(), out c);
                    
                    if (c == '+')
                        cal.add(a, b);
                    if (c == '-')
                        cal.sub(a, b);
                    if (c == '*')
                        cal.mul(a, b);
                    if (c == '/')
                        cal.div(a, b);
                }
            }
            return 0;
        }
    }
