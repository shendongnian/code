    int currentLine = 0;
    //no need use close method with using
    using (StreamReader sr = new StreamReader(File.Open("C:\\Users\\user\\Documents\\Projects\\AdministratorModule//userTextFile.txt", FileMode.Open)))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            switch (++currentLine)
            {
                case 1: user1 = line; break;
                case 2: password1 = line; break;
                case 3: otherVariable = line; break;
                case 4: yetAnotherVariable = line; break;
                ......
            }
            //rest of your logic
           
        }
    }
                
