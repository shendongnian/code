    private void runArgs()
    {
        //==============Already have the numbers? Loop through them and compare==============
        foreach (int i in myRandArr)
        {
            if (numIsMatch(i) == true)
            {
                lista1.Add(i);
            }
        }
        lista1.ForEach(delegate (int num)
        {
            Console.WriteLine(string.Concat("The numbers that match are ", num));
        });
    }
