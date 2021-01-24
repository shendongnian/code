    // Read each line of the file into a string array. Each element
        // of the array is one line of the file.
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
        // Display the file contents by using a foreach loop.
        System.Console.WriteLine("Contents of WriteLines2.txt = ");
        foreach (string line in lines)
        {
           if(line == "Seq Started" && line != "Seq Ended")
           {
            //here you get each line in start to end one by one.
            //apply your logic here.
           }
        }
