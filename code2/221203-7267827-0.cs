            int number = 1;
            //D4 = pad with 0000
            string outputValue = String.Format("{0:D4}", number);
            Console.WriteLine(outputValue);//Prints 0001
            //OR
            outputValue = number.ToString().PadLeft(4, '0');
            Console.WriteLine(outputValue);//Prints 0001 as well
