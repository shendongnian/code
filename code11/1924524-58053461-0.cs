            int totalCharacters = 0;
  
            // Using will do the reader.Close for you. 
            using (StreamReader reader = File.OpenText("C:\\Users\\Lewis\\file.txt"))
            {
                string str = reader.ReadLine();
                while (str != null)
                {
                    totalCharacters += str.Length;
                    str = reader.ReadLine();
                }
            }
            // If you add the $ in front of the string, then you can interpolate expressions 
            Console.Write($"Number of characters in the file is : {totalCharacters}");
