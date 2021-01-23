    int sizeOfOurArray;
            string resultString;
            char buffer;
            resultString = "";
            Console.WriteLine("Введите количество элементов массива: ");
            sizeOfOurArray = int.Parse(Console.ReadLine());
            char[] ourArray = new char[sizeOfOurArray];
            for (int i = 0; i < ourArray.Length; i++)
            {
                Console.WriteLine("Введите значение элементу под номером {0}: ", i);
                buffer = Console.ReadKey().KeyChar;
                resultString += buffer.ToString() + " ";
            }
            
            Console.WriteLine();
            Console.WriteLine(resultString);
            Console.ReadKey();
