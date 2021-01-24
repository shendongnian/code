long length = new System.IO.FileInfo("C:\\Users\\Lewis\\file.txt").Length;
Console.Write($"Number of characters in the file is : {length}");
If you want to count characters to play around with C#, then here is some sample code that might help you
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
