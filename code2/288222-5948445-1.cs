    using System.IO;
    
    // ...
    using(StreamReader rdr = new StreamReader(@"C:\myfile.txt"))
    {
        const string marker = "ANT_SASE_RELEASE_";
        string maxBuildLabel = "";
        int maxBuildNum = int.MinValue;
    
        string line;
        while((line = rdr.ReadLine()) != null)
        {
            int i = line.IndexOf(marker);
            string buildLabel = line.Substring(i + marker.Length);
            int buildNum = int.Parse(buildLabel.Replace(".", ""));
            if (buildNum > maxBuildNum)
            {
                maxBuildLabel = buildLabel;
                maxBuildNum = buildNum;
            }
        }
    
        Console.WriteLine(maxBuildLabel);
    }
