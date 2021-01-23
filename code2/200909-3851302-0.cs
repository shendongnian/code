            Stack s = new Stack();
            Queue q = new Queue();
            bool isRight = true;
            char OpeningBracket = ' ';
            char closingBracket = ' ';
            Console.WriteLine("Enter Brackets");
            string data = Console.ReadLine();
            char[] character = data.ToCharArray();
            for (int i = 0; i < character.Length; i++)
            {
                if (character[i] == '(' || character[i] == '{' ||
                    character[i] == '[')
                {
                    s.Push(character[i]);
                }
                else
                    q.Enqueue(character[i]);
            }
            if (s.Count == 0 || q.Count == 0)            
                isRight = false;
          
            while (s.Count > 0 && q.Count > 0)
            {
                OpeningBracket = (char)s.Pop();
                closingBracket = (char)q.Dequeue();
                if ((OpeningBracket == '(' && closingBracket != ')')
               ||   (OpeningBracket == '[' && closingBracket != ']')
               ||   (OpeningBracket == '{' && closingBracket != '}')
                    )
                {
                    isRight = false;
                }
                
            }
            if (isRight)
                Console.WriteLine(data + " is a Right Sequence.");
            else
                Console.WriteLine(data + " is Not Right Sequence.");
            Console.ReadLine();
        }
