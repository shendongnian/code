    while (!endOfFile)
    {
        //get the next line of the file
        string line = file.readLine();
        EDIT: //Trim WhiteSpaces at start
        line = line.Trim();
        //check for your string
        if (line.StartsWith("addTestingPageContentText"))
        {
            int start1;
            int start2;
            //get the first something by finding a "
            for (start1 = 0; start1 < line.Length; start1++)
            {
                if (line.Substring(start1, 1) == '"'.ToString())
                {
                    start1++;
                    break;
                }
            }
            //get the end of the first something
            for (start2 = start1; start2 < line.Length; start2++)
            {
                if (line.Substring(start2, 1) == '"'.ToString())
                {
                  start2--;
                  break;
                }
            }
            string sometext1 = line.Substring(start1, start2 - start1);
            //get the second something by finding a "
            for (start1 = start2 + 2; start1 < line.Length; start1++)
            {
                if (line.Substring(start1, 1) == '"'.ToString())
                {
                    start1++;
                    break;
                }
            }
            //get the end of the second something
            for (start2 = start1; start2 < line.Length; start2++)
            {
                if (line.Substring(start2, 1) == '"'.ToString())
                {
                    start2--;
                    break;
                }
            }
            string sometext2 = line.Substring(start1, start2 - start1);
        }
    }
         
