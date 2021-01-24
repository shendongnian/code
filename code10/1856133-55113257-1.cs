      static void Calc()
        {
            Console.Write("Enter Second Number: ");
            num2 = Convert.ToDouble(Console.ReadLine());
            if (op == "+")
            {
                Ans = num1 + num2;
            }
            else if (op == "-")
            {
                Ans = num1 - num2;
            }
            else if (op == "/")
            {
                Ans = num1 / num2;
            }
            else if (op == "*")
            {
                Ans = num1 * num2;
            }
           
        }
