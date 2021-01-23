            string mainString = Console.ReadLine();
            string subString = Console.ReadLine();
            for (int i = 0; i <= mainString.Length - subString.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < subString.Length && mainString[i + j] != subString[j]; j++)
                {
                    match = false;
                }
                if (match)
                    Console.WriteLine(i);
            }    
