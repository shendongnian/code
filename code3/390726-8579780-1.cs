        string path = "c:\\users\\Me\\";
        string myString;
        string previousString = "0 0";
        int prevTime = 0;
        bool firstTime = true;
        using(System.IO.StreamReader myFile = new System.IO.StreamReader(path+"t.txt"))
        using(System.IO.StreamWriter file = new System.IO.StreamWriter(path+"t2.txt"))
        {
            while ((myString = myFile.ReadLine()) != null)
            {
                int time = int.Parse(myString.Split(' ')[0]);
                if (!firstTime)
                    while (time > prevTime+1)
                    {
                        prevTime++;
                        previousString = prevTime.ToString() + " " + previousString.Split(' ')[1];
                        file.WriteLine(previousString);
                    } 
                previousString = myString;
                prevTime = int.Parse(previousString.Split(' ')[0]);
                file.WriteLine(myString);
                firstTime = false;
            }       
        } 
