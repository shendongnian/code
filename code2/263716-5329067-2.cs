            foreach( string s in strings )
            {
                if (input >= processedWordList[s])
                {
                    input = input - processedWordList[s];
                }
            }
