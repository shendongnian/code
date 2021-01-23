    string westHand = "KQT5.KJ873..AJ52";
    
            char type = 'S'; //start with spades
    
            string[,] result = new string[westHand.Length - 3, 2];
    
            int counter = 0;
            foreach (string subString2 in westHand.Split('.'))
            {
    
                foreach (char c in subString2)
                {
                    result[counter, 0] = type.ToString();
                    result[counter, 1] = c.ToString();
                    counter++;
                }
                switch (type)
                {
                    case 'S': type = 'H'; break;
                    case 'H': type = 'D'; break;
                    case 'D': type = 'C'; break;
                }
            }
