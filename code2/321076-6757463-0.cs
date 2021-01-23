            // Orginal string
            string s = "bat and ball not pen or boat not phone";
            // Seperator
            string seperate = "not ";
            // Length of the seperator
            int length = seperate.Length;
            // sCopy so you dont touch the original string
            string sCopy = s.ToString();
            // List to store the words, you could use an array if 
            // you count the 'not's.
            List<string> stringList = new List<string>();
            // While the seperator (not ) exists in the string
            while (sCopy.IndexOf(seperate) != -1)
            {
                // Index of the next seperator
                int index = sCopy.IndexOf(seperate);
                // Remove anything before the seperator and the
                // seperator itself.
                sCopy = sCopy.Substring(index + length);
                // In case of multiple spaces remove them.
                sCopy = sCopy.TrimStart(' ');
                // If there are more spaces or more words to come
                // then specify the length
                if (sCopy.IndexOf(' ') != -1)
                {
                    // Cut the word out of sCopy
                    string sub = sCopy.Substring(0, sCopy.IndexOf(' '));
                    // Add the word to the list
                    stringList.Add(sub);
                }
                // Otherwise just get the rest of the string   
                else
                {
                    // Cut the word out of sCopy
                    string sub = sCopy.Substring(0);
                    // Add the word to the list
                    stringList.Add(sub);
                }
            }
            int p = 0;
