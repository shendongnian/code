    class CountOfLettersOfString
    {
        static void Main()
        {
            Console.WriteLine("Enter string to check count of letters");
            string name = Console.ReadLine();
            //Method1
            char[] testedalphabets = new char[26];
            int[] letterCount = new int[26];
            int countTestesd = 0;
            Console.WriteLine($"Given String is:{name}");
            for (int i = 0; i < name.Length - 1; i++)
            {
                int countChar = 1;
                bool isCharTested = false;
                for (int j = 0; j < testedalphabets.Length - 1; j++)
                {
                    if (name[i] == testedalphabets[j])
                    {
                        isCharTested = true;
                        break;
                    }
                }
                if (!isCharTested)
                {
                    testedalphabets[countTestesd] = name[i];
                    for (int k = i + 1; k < name.Length - 1; k++)
                    {
                        if (name[i] == name[k])
                        {
                            countChar++;
                        }
                    }
                    letterCount[countTestesd] = countChar;
                    countTestesd++;
                }
                else
                {
                    continue;
                }
            }
            for (int i = 0; i < testedalphabets.Length - 1; i++)
            {
                if (!char.IsLetter(testedalphabets[i]))
                {
                    continue;
                }
                Console.WriteLine($"{testedalphabets[i]}-{letterCount[i]}");
            }
            //Method2
            var g = from c in name.ToLower().ToCharArray() // make sure that L and l are the same eg
                    group c by c into m
                    select new { Key = m.Key, Count = m.Count() };
            foreach (var item in g)
            {
                Console.WriteLine(string.Format("Character:{0} Appears {1} times", item.Key.ToString(), item.Count));
            }
    
            Console.ReadLine();
        }
    }
