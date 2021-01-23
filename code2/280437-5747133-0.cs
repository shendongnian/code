            List<string> numbers = new List<string>();
            numbers.Add("1");
            numbers.Add("2");
            numbers.Add("3");
            for (int i = 0; i < numbers.Count; i++)
            {
                int n = 0;
                bool success = int.TryParse(numbers[i], out n);
                if (success && n % 2 == 0)
                {
                    numbers[i] = "Even";
                }
            }
            //Output Test Results
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }
