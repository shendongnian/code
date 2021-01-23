    if (int.TryParse(Add(Value1, Value2).ToString(), out total))
            {
                Console.WriteLine("I was able to parse your value to: " + total);
            } else
            {
                Console.WriteLine("Couldn't Parse Value");
            }
         
            Console.ReadLine();
        }
        static int Add(int value1, int value2)
        {
            return value1 + value2;
        }
