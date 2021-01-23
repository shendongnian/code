            string phrase = "TheQuickBrownFox";
            var invalidChars = from i in Enumerable.Range(1, phrase.Length)
                               let ch = phrase[i]
                               where char.IsUpper(ch)
                               select new { Index = i, Character = char.ToLower(ch) };
            foreach (var item in invalidChars)
            {
                phrase = phrase.Remove(item.Index, 1);
                phrase = phrase.Insert(item.Index, " " + item.Character);
            }
            Console.WriteLine(phrase);
            Console.ReadLine();
