            System.IO.StreamReader input = new System.IO.StreamReader(@"originalFile.txt");
            System.IO.StreamWriter output = new System.IO.StreamWriter(@"outputFile.txt");
            String[] allLines = input.ReadToEnd().Split("\n".ToCharArray());
            int numOfLines = allLines.Length;
            int lastLineWeWant = numOfLines - (6);                  //The last index we want. 
            
            for (int x = 0; x < numOfLines; x++)
            {
                if (x > 4 - 1 && x < lastLineWeWant)  //Index has to be greater than num to skip @ start and below the total length - num to skip at end.
                {
                    output.WriteLine(allLines[x].Trim());  //Trim to remove any \r characters.
                }
            }
            input.Close();
            output.Close();
