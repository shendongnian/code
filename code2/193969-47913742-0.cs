            int[] numbers = new int[100];
            for(int i= 0; i < 100; i++)
            {
                numbers[i] = i;
            }
            //For clarity
            IEnumerable strings = numbers.Select<int, string>(j=>j.ToString());
            string[] stringArray = strings.ToArray<string>();
            string output = string.Join(", ", stringArray);
            Console.WriteLine(output);
            //OR 
            //For brevity
            Console.WriteLine(string.Join(", ", numbers.Select<int, string>(j => j.ToString()).ToArray<string>()));
