for (int y = 0; y < b ; y++)
        {
            string s = Console.ReadLine();
            for (int x = 0; x < h ; x++)
            {
                    char c = s[x];
                    if (c.Equals('.') || c.Equals('!') || c.Equals('+') || c.Equals('?'))
                    {
                        input[x, y] = true;
                    }
                    else
                    {
                        input[x, y] = false;
                    }
                
            } 
        }
**EDIT**: I suggest looping through the array to write out the value, the console will just type out the Object type if you feed it to it directly.
