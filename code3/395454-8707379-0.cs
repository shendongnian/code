     Dictionary<string, int> dictionary = new Dictionary<string, int>();
                string sInput = "Hello World, This is a great World. I love this great World";
                sInput = sInput.Replace(",", ""); //Just cleaning up a bit
                sInput = sInput.Replace(".", ""); //Just cleaning up a bit
                string[] arr = sInput.Split(' '); //Create an array of words
                foreach (string word in arr) //let's loop over the words
                {
                    if (word.Length >= 3) //if it meets our criteria of at least 3 letters
                    {
                        if (dictionary.ContainsKey(word)) //if it's in the dictionary
                            dictionary[word] = dictionary[word] + 1; //Increment the count
                        else
                            dictionary[word] = 1; //put it in the dictionary with a count 1
                    }
                }
                foreach (KeyValuePair<string, int> pair in dictionary) //loop through the dictionary
                    Response.Write(string.Format("Key: {0}, Pair: {1}<br />",pair.Key,pair.Value));
