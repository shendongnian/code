    AllLines = new string[MAX]; //only allocate memory here
    using (StreamReader sr = File.OpenText(fileName))
    {
            int x = 0;
            while (!sr.EndOfStream)
            {
                   AllLines[x] = sr.ReadLine();
                   x += 1;
            }
    } //Finished. Close the file
    
    //Now parallel process each line in the file
    Parallel.For(0, AllLines.Length, x =>
    {
        DoYourStuff(AllLines[x]); //do your work here
    });
