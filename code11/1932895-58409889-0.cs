    using (StreamWriter sw = new StreamWriter(dir + "\\" + serialNumber[f] + ".ma"))
    {
    string maHeaderLine1 = "TITLE: S/N:" + serialNumber[f] + "\n";
    string maHeaderLine2 = "ENGLISH(IN)/METRIC(MM) INDICATOR :IN-P\n";
    
    // Open up the file for writing
    //File.WriteAllText(maOutFile, maHeaderLine1);
    
    sw.WriteLine(maHeaderLine1);
    sw.WriteLine(maHeaderLine2);
    }
